using System;

namespace QuanLySachApp
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLySach quanLySach = new QuanLySach();
            int choice;

            do
            {
                Console.WriteLine("===== QUAN LY SACH =====");
                Console.WriteLine("1. Them sach");
                Console.WriteLine("2. Cap nhat thong tin sach");
                Console.WriteLine("3. Xoa sach");
                Console.WriteLine("4. Tim kiem sach");
                Console.WriteLine("5. Hien thi danh sach sach");
                Console.WriteLine("0. Thoat");
                Console.Write("Nhap lua chon cua ban: ");

                // Xử lý lỗi nhập liệu
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Vui long nhap mot so nguyen hop le!");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n=== THEM SACH ===");
                        quanLySach.NhapSach();
                        break;

                    case 2:
                        Console.WriteLine("\n=== CAP NHAT SACH ===");
                        Console.Write("Nhap ID sach muon cap nhat: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            quanLySach.UpdateSach(updateId);
                        }
                        else
                        {
                            Console.WriteLine("ID khong hop le.");
                        }
                        break;

                    case 3:
                        Console.WriteLine("\n=== XOA SACH ===");
                        Console.Write("Nhap ID sach muon xoa: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            if (quanLySach.DeleteById(deleteId))
                            {
                                Console.WriteLine("Xoa thanh cong.");
                            }
                            else
                            {
                                Console.WriteLine("Khong tim thay sach voi ID da nhap.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID khong hop le.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("\n=== TIM KIEM SACH ===");
                        Console.WriteLine("1. Tim theo ID");
                        Console.WriteLine("2. Tim theo ten sach");
                        Console.WriteLine("3. Tim theo ma sach");
                        Console.WriteLine("4. Tim theo tac gia");
                        Console.WriteLine("5. Tim theo nam xuat ban");
                        Console.Write("Lua chon: ");

                        if (int.TryParse(Console.ReadLine(), out int searchChoice))
                        {
                            switch (searchChoice)
                            {
                                case 1:
                                    Console.Write("Nhap ID: ");
                                    if (int.TryParse(Console.ReadLine(), out int searchId))
                                    {
                                        quanLySach.FindAndPrioritizeByID(searchId);
                                    }
                                    else
                                    {
                                        Console.WriteLine("ID khong hop le.");
                                    }
                                    break;

                                case 2:
                                    Console.Write("Nhap ten sach: ");
                                    string searchName = Console.ReadLine();
                                    quanLySach.FindAndPrioritizeByName(searchName);
                                    break;

                                case 3:
                                    Console.Write("Nhap ma sach: ");
                                    string searchMaSach = Console.ReadLine();
                                    quanLySach.FindAndPrioritizeByMaSach(searchMaSach);
                                    break;

                                case 4:
                                    Console.Write("Nhap tac gia: ");
                                    string searchTacGia = Console.ReadLine();
                                    quanLySach.FindAndPrioritizeByTacGia(searchTacGia);
                                    break;

                                case 5:
                                    Console.Write("Nhap nam xuat ban: ");
                                    if (int.TryParse(Console.ReadLine(), out int searchNamXB))
                                    {
                                        quanLySach.FindAndPrioritizeByNamXuatBan(searchNamXB);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Nam xuat ban khong hop le.");
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Lua chon khong hop le.");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Lua chon khong hop le.");
                        }
                        break;

                    case 5:
                        Console.WriteLine("\n=== DANH SACH SACH ===");
                        quanLySach.ShowSach(quanLySach.GetListSach());
                        break;

                    case 0:
                        Console.WriteLine("Thoat chuong trinh.");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
                        break;
                }
                Console.WriteLine();
            } while (choice != 0);
        }
    }
}
