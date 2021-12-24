using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhamThiPhuongNhung_987_De02
{
    class HotelRoom:Room 
    {
        private double hangKhachSan ;
        private string hangPhong ;
        public double HangKsan
        {
            get { return hangKhachSan; }
            set { hangKhachSan = value; }
        }
        public string HangPhong
        {
            get { return hangPhong; }
            set { hangPhong = value; }
        }

        public HotelRoom() : base() { }
        public HotelRoom(string soPhong, int soGiuong, double hangKS, string hangP) : base(soPhong, soGiuong) {
            this.hangKhachSan = hangKS;
            this.hangPhong = hangP;
        }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap hang khach san:");
            hangKhachSan = double.Parse(Console.ReadLine());
            Console.Write("Nhap hang phong:");
            hangPhong = Console.ReadLine();

        }

        public virtual double tinhGiaPhong()
        {

            double giaTang= 0;
            if (hangPhong.CompareTo("Standard") == 0)
            {
                giaTang = 0;
            }
            else if (hangPhong.CompareTo("Premium") == 0 )
            {
                giaTang = 10;
            }
            else if (hangPhong.CompareTo("Deluxe") == 0)
            {
                giaTang = 50 ;
            }
            else if (hangPhong.CompareTo("Luxury") == 0)
            {
                giaTang = 100;
            }

            return ((hangKhachSan*giaCoBan) + giaTang)*this.SoCho;
        
        }
        public override string ToString()
        {
            
            return string.Format("{0,20} {1,20} {2,20} {3,20} {4,15}",this.SP, this.SoCho, this.HangKsan, this.HangPhong,this.tinhGiaPhong());
        }
    }
}
