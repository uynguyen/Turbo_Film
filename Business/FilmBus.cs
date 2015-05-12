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

             MAX_PRODUCT_EACHPAGE = getMaxProductOnEachPage();

             
             MAX_INDEX_PAGE = getMaxIndexPage();
                
        }
        
        public int  getMaxIndexPage(){
            BangThamSo temp = db.BangThamSo.Where(x => x.TenThamSo == "GiaTriTrangLonNhatMoiLanPhanTrang").FirstOrDefault();
            return Int32.Parse(temp.GiaTri);
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

        public int getIDOfCountry(string country)
        {
            int t = (from entry in db.DanhMucNuocSanXuat where entry.TenNuoc.Equals(country) select entry.MaSo).Single();
            return t;
            
        }
        public int getIDOfType(string type)
        {
            int t = (from entry in db.DanhMucTheLoai where entry.TenTheLoai.Equals(type) select entry.MaSo).Single();
            return t;
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


// Cac ham chuc nang search cua Xanh

        public List<Phim> searchFilm(string nameFilm, int page, out int maxPage)
        {          

    // Giải quyết vấn đề dạng 1
            var t = from entry in db.Phim select entry;
            if (!String.IsNullOrEmpty(nameFilm))
                t = t.Where(e => e.TenPhim.Contains(nameFilm) && e.TinhTrang == true);
            maxPage = countPageSearch(t.ToList());

            if(t.ToList().Count != 0)
            return t.OrderBy(x => x.MaSo).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
            else
            {
                // Giải quyết vấn đề dạng 3
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
                return result.Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
            }
        }

        internal int countPageSearch(List<Phim> searchResult)
        {
            int size = searchResult.Count;

            int page = size / MAX_INDEX_PAGE;
            if (size % FilmBus.MAX_PRODUCT_EACHPAGE != 0)
            {
                page++;
            }
            return page;
        }



        static int LevenshteinDistance(string s, string t)
        {
            s = s.ToLower();
            t = t.ToLower();
            int[,] d = new int[s.Length + 1, t.Length + 1];
            for (int i = 0; i <= s.Length; i++)
                d[i, 0] = i;
            for (int j = 0; j <= t.Length; j++)
                d[0, j] = j;
            for (int j = 1; j <= t.Length; j++)
                for (int i = 1; i <= s.Length; i++)
                    if (s[i - 1] == t[j - 1])
                        d[i, j] = d[i - 1, j - 1];  //no operation
                    else
                        d[i, j] = Math.Min(Math.Min(
                            d[i - 1, j] + 1,    //a deletion
                            d[i, j - 1] + 1),   //an insertion
                            d[i - 1, j - 1] + 1 //a substitution
                            );
            return d[s.Length, t.Length];
        }

        public bool testPun(string a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == ',')
                    return true;
            }
            return false;
        }
        public List<Phim> searchFilm4(string actor, string directer, string country, string type, int page, out int maxPage)
        {            
            //List<Phim> lst = db.Phim.ToList();
            //List<Phim> result = new List<Phim>();
            //return result;

            int maNuoc = getIDOfCountry(country); 
            int maTheLoai = getIDOfType(type); 

            var t1 = from entry in db.Phim select entry;
            if (!String.IsNullOrEmpty(actor) || !String.IsNullOrEmpty(directer))
               t1 = t1.Where(e => e.DienVien.Contains(actor) && e.DaoDien.Contains(directer) 
                                                && e.MS_NuocSX == maNuoc && e.MS_TheLoai == maTheLoai);
            maxPage = countPageSearch(t1.ToList());
       //     if (t1.ToList().Count != 0)
       //     {
                return t1.OrderBy(x => x.MaSo).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
        //    }
            //else
            //{

            //}
        }

        public List<Phim> findByGenre(int genreID, int page, string strSort, bool isASC)
        {
            if (isASC)
            {
                switch (strSort)
                {
                    case "ID":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderBy(x => x.MaSo).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Name":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderBy(x => x.TenPhim).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Date":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderBy(x => x.NgayPhatHanh).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Duration":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderBy(x => x.ThoiLuong).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Genre":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderBy(x => x.MS_TheLoai).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Rank":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderBy(x => x.DiemDanhGia).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                }
            }
            else
            {
                switch (strSort)
                {
                    case "ID":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderByDescending(x => x.MaSo).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Name":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderByDescending(x => x.TenPhim).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Date":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderByDescending(x => x.NgayPhatHanh).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Duration":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderByDescending(x => x.ThoiLuong).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Genre":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderByDescending(x => x.MS_TheLoai).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                    case "Rank":
                        return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderByDescending(x => x.DiemDanhGia).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
                }
            }
            return db.Phim.Where(x => x.TinhTrang == true && x.MS_TheLoai == genreID).OrderBy(x => x.MaSo).Skip(page * MAX_PRODUCT_EACHPAGE - MAX_PRODUCT_EACHPAGE).Take(MAX_PRODUCT_EACHPAGE).ToList();
        }

        public float calculateAvgRank(int p)
        {
            float result = 0;

            List<DanhGia> lstJudge = db.DanhGia.Where(x => x.MS_Phim == p).ToList();
            if (lstJudge.Count == 0)
                return 0;

            foreach (DanhGia item in lstJudge)
            {
                result += (float) item.DiemDanhGia;

            }

            return result  / lstJudge.Count;
        }

        public int countRateTimes(int p)
        {
            return db.DanhGia.Where(x => x.MS_Phim == p).ToList().Count;

        }


        public int getMaxProductOnEachPage()
        {
            BangThamSo temp = db.BangThamSo.Where(x => x.TenThamSo == "SoPhimTrenMotTrang").FirstOrDefault();
            return Int32.Parse(temp.GiaTri);
        }

        public bool changeMaxProductOnEachPage(int maxProductOnEachPage)
        {
            BangThamSo temp = db.BangThamSo.Where(x => x.TenThamSo == "SoPhimTrenMotTrang").FirstOrDefault();
            temp.GiaTri = maxProductOnEachPage.ToString();
            db.SaveChanges();
            return true;
        }
    }
}
