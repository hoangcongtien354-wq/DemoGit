using System;
using System.Collections.Generic;

namespace QuanLySachApp
{
    public class QuanLySach
    {
        private List<Sach> ListSach;

        public QuanLySach()
        {
            ListSach = new List<Sach>();
        }

        private int GenerateID()
        {
            int max = 1;
            if (ListSach.Count > 0)
            {
                max = ListSach[0].ID;
                foreach (Sach sach in ListSach)
                {
                    if (max < sach.ID)
                    {
                        max = sach.ID;
                    }
                }
                max++;
            }
            return max;
        }

        public void NhapSach()
        {
            Sach sach = new Sach();
            sach.ID = GenerateID();

            Console.Write("Nhap ma sach: ");
            sach.MaSach = Console.ReadLine();

            Console.Write("Nhap ten sach: ");
            sach.TenSach = Console.ReadLine();

            Console.Write("Nhap tac gia: ");
            sach.TacGia = Console.ReadLine();

            Console.Write("Nhap nha xuat ban: ");
            sach.NhaXuatBan = Console.ReadLine();

            Console.Write("Nhap nam xuat ban: ");
            sach.NamXuatBan = int.Parse(Console.ReadLine());

            ListSach.Add(sach);
        }

        public void UpdateSach(int id)
        {
            Sach sach = FindByID(id);
            if (sach != null)
            {
                Console.Write("Nhap ma sach (de trong neu khong thay doi): ");
                string maSach = Console.ReadLine();
                if (!string.IsNullOrEmpty(maSach))
                {
                    sach.MaSach = maSach;
                }

                Console.Write("Nhap ten sach (de trong neu khong thay doi): ");
                string tenSach = Console.ReadLine();
                if (!string.IsNullOrEmpty(tenSach))
                {
                    sach.TenSach = tenSach;
                }

                Console.Write("Nhap tac gia (de trong neu khong thay doi): ");
                string tacGia = Console.ReadLine();
                if (!string.IsNullOrEmpty(tacGia))
                {
                    sach.TacGia = tacGia;
                }

                Console.Write("Nhap nha xuat ban (de trong neu khong thay doi): ");
                string nhaXuatBan = Console.ReadLine();
                if (!string.IsNullOrEmpty(nhaXuatBan))
                {
                    sach.NhaXuatBan = nhaXuatBan;
                }

                Console.Write("Nhap nam xuat ban (de trong neu khong thay doi): ");
                string namStr = Console.ReadLine();
                if (!string.IsNullOrEmpty(namStr))
                {
                    sach.NamXuatBan = int.Parse(namStr);
                }
            }
            else
            {
                Console.WriteLine("Khong tim thay sach voi ID: {0}.", id);
            }
        }

        public bool DeleteById(int id)
        {
            Sach sach = FindByID(id);
            return sach != null && ListSach.Remove(sach);
        }

        public Sach FindByID(int id)
        {
            return ListSach.Find(sach => sach.ID == id);
        }

        public void FindAndPrioritizeByID(int id)
        {
            Sach sach = FindByID(id);
            if (sach != null)
            {
                ListSach.Remove(sach);
                ListSach.Insert(0, sach);

                Console.WriteLine("Ket qua tim kiem theo ID (uu tien len dau):");
                ShowSach(ListSach);
            }
            else
            {
                Console.WriteLine("Khong tim thay sach voi ID: {0}.", id);
            }
        }

        public void FindAndPrioritizeByName(string tenSach)
        {
            List<Sach> searchResult = new List<Sach>();
            foreach (Sach sach in ListSach)
            {
                if (sach.TenSach.ToUpper().Contains(tenSach.ToUpper()))
                {
                    searchResult.Add(sach);
                }
            }

            if (searchResult.Count > 0)
            {
                foreach (Sach sach in searchResult)
                {
                    ListSach.Remove(sach);
                }
                ListSach.InsertRange(0, searchResult);

                Console.WriteLine("Ket qua tim kiem theo ten sach (uu tien len dau):");
                ShowSach(ListSach);
            }
            else
            {
                Console.WriteLine("Khong tim thay sach voi ten: {0}.", tenSach);
            }
        }

        public void FindAndPrioritizeByMaSach(string maSach)
        {
            List<Sach> searchResult = new List<Sach>();
            foreach (Sach sach in ListSach)
            {
                if (sach.MaSach.ToUpper().Contains(maSach.ToUpper()))
                {
                    searchResult.Add(sach);
                }
            }

            if (searchResult.Count > 0)
            {
                foreach (Sach sach in searchResult)
                {
                    ListSach.Remove(sach);
                }
                ListSach.InsertRange(0, searchResult);

                Console.WriteLine("Ket qua tim kiem theo ma sach (uu tien len dau):");
                ShowSach(ListSach);
            }
            else
            {
                Console.WriteLine("Khong tim thay sach nao voi ma sach: {0}.", maSach);
            }
        }

        public void FindAndPrioritizeByTacGia(string tacGia)
        {
            List<Sach> searchResult = new List<Sach>();
            foreach (Sach sach in ListSach)
            {
                if (sach.TacGia.ToUpper().Contains(tacGia.ToUpper()))
                {
                    searchResult.Add(sach);
                }
            }

            if (searchResult.Count > 0)
            {
                foreach (Sach sach in searchResult)
                {
                    ListSach.Remove(sach);
                }
                ListSach.InsertRange(0, searchResult);

                Console.WriteLine("Ket qua tim kiem theo tac gia (uu tien len dau):");
                ShowSach(ListSach);
            }
            else
            {
                Console.WriteLine("Khong tim thay sach nao cua tac gia: {0}.", tacGia);
            }
        }

        public void FindAndPrioritizeByNamXuatBan(int namXuatBan)
        {
            List<Sach> searchResult = new List<Sach>();
            foreach (Sach sach in ListSach)
            {
                if (sach.NamXuatBan == namXuatBan)
                {
                    searchResult.Add(sach);
                }
            }

            if (searchResult.Count > 0)
            {
                foreach (Sach sach in searchResult)
                {
                    ListSach.Remove(sach);
                }
                ListSach.InsertRange(0, searchResult);

                Console.WriteLine("Ket qua tim kiem theo nam xuat ban (uu tien len dau):");
                ShowSach(ListSach);
            }
            else
            {
                Console.WriteLine("Khong tim thay sach nao xuat ban nam: {0}.", namXuatBan);
            }
        }

        public void ShowSach(List<Sach> listSach)
        {
            Console.WriteLine("{0,-5} {1,-15} {2,-25} {3,-20} {4,-20} {5,-10}",
                "ID", "Ma Sach", "Ten Sach", "Tac Gia", "NXB", "Nam XB");
            foreach (Sach sach in listSach)
            {
                Console.WriteLine("{0,-5} {1,-15} {2,-25} {3,-20} {4,-20} {5,-10}",
                    sach.ID, sach.MaSach, sach.TenSach, sach.TacGia, sach.NhaXuatBan, sach.NamXuatBan);
            }
        }
        public void MaSach(List<Sach> listSach)
        {
            Console.WriteLine("{0,-15} {1,-5} {2,-25} {3,-20} {4,-20} {5,-10}",
                "Ma Sach", "ID", "Ten Sach", "Tac Gia", "NXB", "Nam XB");
            foreach (Sach sach in listSach)
            {
                Console.WriteLine("{0,-15} {1,-5} {2,-25} {3,-20} {4,-20} {5,-10}",
                    sach.MaSach, sach.ID, sach.TenSach, sach.TacGia, sach.NhaXuatBan, sach.NamXuatBan);
            }
        }

        public void TenSach(List<Sach> listSach)
        {
            Console.WriteLine("{0,-25} {1,-5} {2,-15} {3,-20} {4,-20} {5,-10}",
                "Ten Sach", "ID", "Ma Sach", "Tac Gia", "NXB", "Nam XB");
            foreach (Sach sach in listSach)
            {
                Console.WriteLine("{0,-25} {1,-5} {2,-15} {3,-20} {4,-20} {5,-10}",
                    sach.TenSach, sach.ID, sach.MaSach, sach.TacGia, sach.NhaXuatBan, sach.NamXuatBan);
            }
        }

        public void NamXuatBan(List<Sach> listSach)
        {
            Console.WriteLine("{0,-10} {1,-5} {2,-15} {3,-25} {4,-20} {5,-20}",
                "Nam XB", "ID", "Ma Sach", "Ten Sach", "Tac Gia", "NXB");
            foreach (Sach sach in listSach)
            {
                Console.WriteLine("{0,-10} {1,-5} {2,-15} {3,-25} {4,-20} {5,-20}",
                    sach.NamXuatBan, sach.ID, sach.MaSach, sach.TenSach, sach.TacGia, sach.NhaXuatBan);
            }
        }


        public void TacGia(List<Sach> listSach)
        {
            Console.WriteLine("{0,-20} {1,-5} {2,-15} {3,-25} {4,-20} {5,-10}",
                "Tac Gia", "ID", "Ma Sach", "Ten Sach", "NXB", "Nam XB");
            foreach (Sach sach in listSach)
            {
                Console.WriteLine("{0,-20} {1,-5} {2,-15} {3,-25} {4,-20} {5,-10}",
                    sach.TacGia, sach.ID, sach.MaSach, sach.TenSach, sach.NhaXuatBan, sach.NamXuatBan);
            }
        }

        public List<Sach> GetListSach()
        {
            return ListSach;
        }
    }
} 