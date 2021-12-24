using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PhamThiPhuongNhung_987_De02
{
    class Program
    {
        public static List<HotelRoom> dsHoltelRoom = new List<HotelRoom>();
        static void Main(string[] args)

        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            try
            {
                while (true)
                {

                    Console.WriteLine("======================================MENU CHƯƠNG TRÌNH======================================");
                    Console.WriteLine("1. Thêm phòng");
                    Console.WriteLine("2. Hiển thị danh sách phòng");
                    Console.WriteLine("3. Sắp xếp phòng");
                    Console.WriteLine("4. Thoát chương trình");
                    Console.WriteLine("----------------------------------------------------------------------------------------------");
                    Console.Write("Chọn vào mục bạn muốn xem : ");
                    int choose = int.Parse(Console.ReadLine());
                    
                    
                    
                   if (choose == 4) break;
                    switch (choose)
                    {
                        case 1:
                            Console.WriteLine("=============================Nhập thông tin phòng cần thêm=======================");
                            InputRoom();
                            break;
                        case 2:
                            Console.WriteLine("==============================Danh phòng khách sạn vừa nhập ==========================");
                            Console.WriteLine("{0,20} {1,20} {2,20} {3,20} {4,15}", "Mã phòng", "Số chỗ", "Hạng khách sạn", "Hạng phòng", "Giá Phòng");
                            OutPutRoom();
                            break;
                        case 3:
                            Console.WriteLine("==============================Danh sách phòng khi sắp xếp ====================");
                            Console.WriteLine("{0,20} {1,20} {2,20} {3,20} {4,15}", "Mã phòng", "Số chỗ", "Hạng khách sạn", "Hạng phòng", "Giá Phòng");
                            Sort();
                            OutPutRoom();
                            break;
                        default:

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Bạn đã nhập sai lựa chọn, nhấn Enter để tiếp tục!");
                            Console.ReadLine();
                            Console.ResetColor();

                            break;
                    }
                }
            }catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void InputRoom()
        {
            string soPhong, hangPhong;
            int soLuongGiuong;
            double hangKhachSan;

            Console.Write("Nhap vao ma so phong :");
            soPhong = Console.ReadLine();
            Console.Write("Nhap vao ma so luong giuong :");
            soLuongGiuong = int.Parse(Console.ReadLine());
            Console.Write("Nhap hang khach san:");
            hangKhachSan = double.Parse(Console.ReadLine());
            Console.Write("Nhap hang phong:");
            hangPhong = Console.ReadLine();

            HotelRoom hotelRoom = new HotelRoom(soPhong, soLuongGiuong, hangKhachSan, hangPhong);
            foreach (HotelRoom phong in dsHoltelRoom)
            {
                if (phong.SP.CompareTo(hotelRoom.SP) == 0)
                {
                    Console.WriteLine("Mã số phòng đã tồn tại , không được thêm phong này vào danh sách!");
                    return;
                }
            }
            //HotelRoom them = new HotelRoom(soPhong, soLuongGiuong, hangKhachSan, hangPhong);
            dsHoltelRoom.Add(new HotelRoom(soPhong, soLuongGiuong, hangKhachSan, hangPhong));
            Console.WriteLine("-->Thêm thành công !");
        }
        public static void OutPutRoom()
        {
            foreach(HotelRoom item in dsHoltelRoom)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public static void Sort()
        {
            dsHoltelRoom.Sort(delegate (HotelRoom phong1, HotelRoom phong2)
            {
                return phong1.tinhGiaPhong().CompareTo(phong2.tinhGiaPhong());
            });
        }
    }
}
