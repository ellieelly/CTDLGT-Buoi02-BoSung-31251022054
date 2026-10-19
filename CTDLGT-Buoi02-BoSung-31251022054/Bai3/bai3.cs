using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251022054.Bai3
{
    internal class bai3 //Xây dựng chương trình quản lý sinh viên bằng List<Student>. Mỗi sinh viên gồm mã sinh viên, họ tên và điểm tổng kết. Chương trình chạy theo menu đến khi người dùng chọn thoát.
    {
        public class Student
        {
        // Mã số sinh viên (khóa chính định danh duy nhất)
        public string Id { get; set; } = "";
        // Họ và tên đầy đủ của sinh viên
        public string FullName { get; set; } = "";
        // Điểm số của sinh viên (thang điểm 10)
        public double Score { get; set; }
    }
    class Program
    {
        // Hàm tìm kiếm vị trí sinh viên theo mã Id (duyệt tuyến tính thủ công, không dùng LINQ)
        static int TimViTriTheoId(List<Student> list, string id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                // So sánh chuỗi không phân biệt chữ hoa, chữ thường
                if (list[i].Id.Equals(id, StringComparison.OrdinalIgnoreCase))
                {
                    // Ngắt và trả về ngay chỉ số khi tìm thấy (Early Exit)
                    return i;
                }
            }
            // Trả về -1 nếu duyệt hết danh sách mà không tìm thấy
            return -1;
        }
        // Hàm thêm sinh viên có kiểm tra tính hợp lệ của dữ liệu
        static void ThemSinhVien(List<Student> list, string id, string name, double score)
        {
            Console.Write($"Thêm sinh viên [{id} - {name} - {score}]: ");

            // Kiểm tra phạm vi hợp lệ của điểm số
            if (score < 0 || score > 10)
            {
                Console.WriteLine("TỪ CHỐI (Điểm phải nằm trong đoạn [0, 10]!)");
                return;
            }
            // Kiểm tra xem mã sinh viên đã tồn tại trước đó hay chưa
            if (TimViTriTheoId(list, id) != -1)
            {
                Console.WriteLine("TỪ CHỐI (Mã sinh viên đã tồn tại!)");
                return;
            }
            // Thêm đối tượng sinh viên mới vào danh sách
            list.Add(new Student { Id = id, FullName = name, Score = score });
            Console.WriteLine("THÀNH CÔNG");
        }
        // Hàm tìm kiếm và in ra sinh viên theo từ khóa họ tên
        static void TimKiemTheoTen(List<Student> list, string tuKhoa)
        {
            Console.WriteLine($"KẾT QUẢ TÌM KIẾM VỚI TỪ KHÓA \"{tuKhoa}\"");
            bool timThay = false;
            for (int i = 0; i < list.Count; i++)
            {
                // Kiểm tra chuỗi tên có chứa từ khóa hay không
                if (list[i].FullName.IndexOf(tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    Console.WriteLine($"- Mã: {list[i].Id} | Tên: {list[i].FullName} | Điểm: {list[i].Score}");
                    timThay = true;
                }
            }
            if (!timThay)
            {
                Console.WriteLine("Không tìm thấy sinh viên nào phù hợp.");
            }
        }
        // Hàm xóa sinh viên theo mã Id
        static void XoaSinhVien(List<Student> list, string id)
        {
            Console.Write($"Xóa sinh viên mã [{id}]: ");
            int viTri = TimViTriTheoId(list, id);
            if (viTri == -1)
            {
                Console.WriteLine("TỪ CHỐI (Không tìm thấy mã sinh viên để xóa!)");
                return;
            }
            // Xóa phần tử tại vị trí tìm thấy
            list.RemoveAt(viTri);
            Console.WriteLine("XÓA THÀNH CÔNG");
        }
        // Hàm hiển thị danh sách sinh viên và tính toán thống kê
        static void InDanhSachVaThongKe(List<Student> list)
        {
            Console.WriteLine("DANH SÁCH SINH VIÊN VÀ THỐNG KÊ");
            // Xử lý trường hợp biên: danh sách rỗng
            if (list.Count == 0)
            {
                Console.WriteLine("Danh sách hiện đang rỗng.");
                return;
            }
            double tongDiem = 0;
            int demDat = 0;
            for (int i = 0; i < list.Count; i++)
            {
                tongDiem += list[i].Score;
                // Đếm sinh viên có điểm đạt từ 5.0 trở lên
                if (list[i].Score >= 5.0) demDat++;

                Console.WriteLine($"{list[i].Id,-6} | {list[i].FullName,-20} | Điểm: {list[i].Score,4:F1}");
            }
            // Ép kiểu/tính điểm trung bình cả lớp
            double diemTB = tongDiem / list.Count;
            Console.WriteLine($"-> Điểm trung bình cả lớp: {diemTB:F2}");
            Console.WriteLine($"-> Số sinh viên đạt (>= 5.0): {demDat}/{list.Count}");
        }
            static void Main()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                List<Student> dsSinhVien = new List<Student>();
                // 1. Nạp 5 sinh viên mẫu hợp lệ
                ThemSinhVien(dsSinhVien, "SV01", "Nguyen Van An", 8.5);
                ThemSinhVien(dsSinhVien, "SV02", "Tran Thi Binh", 4.0);
                ThemSinhVien(dsSinhVien, "SV03", "Le Van Cuong", 7.0);
                ThemSinhVien(dsSinhVien, "SV04", "Pham Thi Dung", 9.5);
                ThemSinhVien(dsSinhVien, "SV05", "Hoang Van Em", 3.0);
                // 2. Kiểm thử các trường hợp dữ liệu không hợp lệ
                ThemSinhVien(dsSinhVien, "SV01", "Nguyen Trung Ma", 9.0); // Trùng mã
                ThemSinhVien(dsSinhVien, "SV06", "Diem Am", -1.0);        // Điểm âm
                ThemSinhVien(dsSinhVien, "SV07", "Diem Qua 10", 11.0);     // Điểm > 10
                // 3. Hiển thị danh sách và thống kê điểm
                InDanhSachVaThongKe(dsSinhVien);
                // 4. Tìm kiếm theo tên
                TimKiemTheoTen(dsSinhVien, "an");
                TimKiemTheoTen(dsSinhVien, "khong_ton_tai");
                // 5. Xóa sinh viên
                XoaSinhVien(dsSinhVien, "SV02"); // Xóa thành công
                XoaSinhVien(dsSinhVien, "SV99"); // Xóa mã không có thực
                // 6. Hiển thị lại danh sách sau khi xóa
                InDanhSachVaThongKe(dsSinhVien);
            }
        }
    }
}