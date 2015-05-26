
       $(document).ready(function () {
           $('.popup-with-zoom-anim').magnificPopup({
               type: 'inline',
               fixedContentPos: false,
               fixedBgPos: true,
               overflowY: 'auto',
               closeBtnInside: true,
               preloader: false,
               midClick: true,
               removalDelay: 300,
               mainClass: 'my-mfp-zoom-in'
           });
       });
     
           $(function () {
               $(".knob").knob();
           });
           $(function () {
               var match = document.cookie.match(new RegExp('color=([^;]+)'));
               if (match) var color = match[1];
               if (color) {
                   $('body').removeClass(function (index, css) {
                       return (css.match(/\btheme-\S+/g) || []).join(' ')
                   })
                   $('body').addClass('theme-' + color);
               }

               $('[data-popover="true"]').popover({ html: true });

           });

           $(function () {
               var uls = $('.sidebar-nav > ul > *').clone();
               uls.addClass('visible-xs');
               $('#main-menu').append(uls.clone());
           });

           $("[rel=tooltip]").tooltip();
           $(function () {
               $('.demo-cancel-click').click(function () { return false; });
           });


           $(document).ready(function () {

               $('.selectpicker').selectpicker();

               $('#permission').change(function () {
                   $("#myModal").modal();
               });

           });

           $(function () {
               $("#datepicker").datepicker();
           });