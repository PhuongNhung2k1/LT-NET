using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhamThiPhuongNhung_987_De02
{
    class Room
    {
        private string soPhong;
        private int soCho;
        public static int giaCoBan = 100;
        public string SP
        {
            get { return soPhong; }
            set { value = soPhong; }
        }
         public int SoCho
        {
            get { return soCho; }
            set { value = SoCho; }
        }
        public Room() { }
        public Room(string SP, int soChoNam) {
            this.soPhong = SP;
            this.soCho = soChoNam;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap vao ma so phong :");
            soPhong = Console.ReadLine();
            Console.Write("Nhap vao ma so luong giuong :");
            soCho = int.Parse(Console.ReadLine());

        }
    }
}
