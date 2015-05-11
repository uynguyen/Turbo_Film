using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class FilmBus
    {
        private TURBO_PHIMEntities db = new TURBO_PHIMEntities();
        public static int MAX_PRODUCT_EACHPAGE = 0;
        public static int MAX_INDEX_PAGE = 0;
        public FilmBus(){
             BangThamSo temp = db.BangThamSo.Where(x => x.TenThamSo == "SoPhimTrenMotTrang").FirstOrDefault();
             MAX_PRODUCT_EACHPAGE = Int32.Parse(temp.GiaTri);

             temp = db.BangThamSo.Where(x => x.TenThamSo == "GiaTriTrangLonNhatMoiLanPhanTrang").FirstOrDefault();
             MAX_INDEX_PAGE = Int32.Parse(temp.GiaTri);
                
        }
        
        public List<Phim> getAllFilms(int page, String strSort, bool isASC)
        {
            if(isASC)
            {
                switch (strSort)
                {
                    case "ID":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderBy(x => x.MaSo).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Name":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderBy(x => x.TenPhim).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Date":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderBy(x => x.NgayPhatHanh).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Duration":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderBy(x => x.ThoiLuong).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Genre":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderBy(x => x.MS_TheLoai).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Rank":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderBy(x => x.DiemDanhGia).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                }
            }
            else
            {
                switch (strSort)
                {
                    case "ID":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderByDescending(x => x.MaSo).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Name":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderByDescending(x => x.TenPhim).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Date":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderByDescending(x => x.NgayPhatHanh).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Duration":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderByDescending(x => x.ThoiLuong).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Genre":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderByDescending(x => x.MS_TheLoai).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Rank":
                        return db.Phim.Where(x => x.TinhTrang == true).OrderByDescending(x => x.DiemDanhGia).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                }
            }
            return  db.Phim.Where(x => x.TinhTrang == true).OrderBy(x => x.MaSo).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
           
        }



        public string getTypeOfFilm(int? id)
        {
            return db.DanhMucTheLoai.Find(id).TenTheLoai;
        }
        public string getCountryOfFilm(int? id)
        {
            return db.DanhMucNuocSanXuat.Find(id).TenNuoc;
        }


        public bool deleteFilm(string codeFilm)
        {
            int id = Int32.Parse(codeFilm);
            //Đánh dấu xóa phim
            Phim temp = db.Phim.Find(id);

            temp.TinhTrang = false;

            //Đánh dấu xóa những bài nhận xét liên quan

            List<BaiNhanXet> lstReview = db.BaiNhanXet.Where(x => x.MS_Phim == id).ToList();
            foreach (BaiNhanXet item in lstReview)
            {
                item.TinhTrang = false;
            }


            db.SaveChanges();



            return true;
        }



        public List<DanhMucTheLoai> getAllGeners()
        {
            return db.DanhMucTheLoai.Where(x => x.TinhTrang == true).ToList();
        }
        public List<DanhMucNuocSanXuat> getAllCountry()
        {
            return db.DanhMucNuocSanXuat.Where(x => x.TinhTrang == true).ToList();
        }

        public bool createNewGenre(string name)
        {
            try
            {
                DanhMucTheLoai genre = new DanhMucTheLoai();
                genre.TenTheLoai = name;
                genre.TinhTrang = true;
                db.DanhMucTheLoai.Add(genre);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }




        public bool deleteGenre(int id)
        {
            try
            {
                DanhMucTheLoai genre = db.DanhMucTheLoai.Find(id);
                genre.TinhTrang = false;

                //Đổi thể loại của các bộ phim liên quan thành "khác"

                List<DanhMucTheLoai> diffGenre = db.DanhMucTheLoai.Where(x => x.TenTheLoai.Equals("Khác")).ToList();

                List<Phim> lstFilms = db.Phim.Where(x => x.MS_TheLoai == id).ToList();
                foreach (Phim item in lstFilms)
                {
                    item.MS_TheLoai = diffGenre[0].MaSo;
                }


                db.SaveChanges();



                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           


        }

        public bool addNewFilmd(Phim p)
        {
            try {
                if (p.MS_NuocSX == null)
                {
                    DanhMucNuocSanXuat diffCountry = db.DanhMucNuocSanXuat.Where(x => x.TenNuoc.Equals("Khác")).FirstOrDefault();
                    p.MS_NuocSX = diffCountry.MaSo;
                }
                if (p.MS_TheLoai == null)
                {
                    DanhMucTheLoai diffGenre = db.DanhMucTheLoai.Where(x => x.TenTheLoai.Equals("Khác")).FirstOrDefault();
                    p.MS_TheLoai = diffGenre.MaSo;
                }

                db.Phim.Add(p);



                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

           
        }

        public Phim getFilmByID(string codeFilm)
        {
            return db.Phim.Find(Int32.Parse(codeFilm));
        }

        public bool editFilm(Phim p)
        {
            try
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();


                return true;
            }
           catch(Exception e)
            {
                return false;
            }

        }

        /// <summary>
        /// Hàm tính toán số lượng page lớn nhất của danh sách phim được hiển thị
        /// </summary>
        /// <returns></returns>
        public int countPage()
        {
            int size = db.Phim.Where(x => x.TinhTrang == true).ToList().Count();

            int page = size / MAX_PRODUCT_EACHPAGE;
            if (size % MAX_PRODUCT_EACHPAGE != 0)
            {
                page++;
            }
            return page;
        }

        public bool editGenre(int p, string newName)
        {
            try
            {
                DanhMucTheLoai genre = db.DanhMucTheLoai.Find(p);
                genre.TenTheLoai = newName;
                db.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
           
        }

        public bool createNewCountry(string name)
        {
            try
            {
                DanhMucNuocSanXuat country = new DanhMucNuocSanXuat();
                country.TenNuoc = name;
                country.TinhTrang = true;
                db.DanhMucNuocSanXuat.Add(country);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public bool editCountry(int p, string newName)
        {
            try
            {
                DanhMucNuocSanXuat genre = db.DanhMucNuocSanXuat.Find(p);
                genre.TenNuoc = newName;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
           
        }

        public bool deleteCountry(int id)
        {
            try
            {
                DanhMucNuocSanXuat country = db.DanhMucNuocSanXuat.Find(id);
                country.TinhTrang = false;

                //Đổi nước sản xuấti của các bộ phim liên quan thành "khác"

                List<DanhMucNuocSanXuat> diffCountry = db.DanhMucNuocSanXuat.Where(x => x.TenNuoc.Equals("Khác")).ToList();

                List<Phim> lstFilms = db.Phim.Where(x => x.MS_NuocSX == id).ToList();
                foreach (Phim item in lstFilms)
                {
                    item.MS_NuocSX = diffCountry[0].MaSo;
                }


                db.SaveChanges();



                return true;
            }
           catch(Exception e)
            {
                return false;
            }
        }

        // Cac ham chuc nang search cua Xanh
        public List<Phim> searchFilm(string nameFilm)
        {
            List<Phim> lst = db.Phim.ToList();

            List<Phim> result = new List<Phim>();
            foreach (Phim item in lst)
            {
                int temp = LevenshteinDistance(nameFilm, item.TenPhim);
                if (temp <= 5)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        private int LevenshteinDistance(string nameFilm, string p)
        {
            throw new NotImplementedException();
        }
     
    }
}
