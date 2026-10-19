using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251022054.Bai1
{
    internal class bai1 //Nhập số nguyên n và n số nguyên. Chương trình in tổng, giá trị nhỏ nhất, giá trị lớn nhất, trung bình cộng, số phần tử âm, dương và bằng 0; sau đó đảo mảng tại chỗ và in kết quả.
    {
        static void Main(string[] args)
        {
            //Nhập số lượng phần tử n
            Console.Write("Nhap so nguyen n: ");
            int n = int.Parse(Console.ReadLine());
            //Nhập n số nguyên trên cùng 1 dòng
            Console.Write($"Nhap {n} so nguyen: ");
            string[] tokens = Console.ReadLine().Split(' ');
            //Khởi tạo mảng số nguyên lưu trữ n phần tử
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                //Chuyển đổi từ chuỗi sang số nguyên và lưu vào mảng
                arr[i] = int.Parse(tokens[i]);
            }
            //Dùng long để tránh tràn số khi cộng nhiều số nguyên
            long tong = 0;
            //Khởi tạo min và max bằng phần tử đầu arr[0] để thuộc tập dữ liệu đầu vào 
            int min = arr[0];
            int max = arr[0];
            //Khởi tạo biến đếm số âm, số dương và số 0
            int demAm = 0;
            int demDuong = 0;
            int demZero = 0;
            //Vòng lặp duyệt qua n phần tử (từ 0 -> n-1)
            for (int i = 0; i < n; i++)
            {
                //Cộng dồn phần tử hiện tại vào tổng tích lũy
                tong += arr[i];
                //Cập nhật giá trị nhỏ nhất nếu gặp phần tử nhỏ hơn min
                if (arr[i] < min) min = arr[i];
                //Cập nhật giá trị lớn nhất nếu gặp phần tử lớn hơn max
                if (arr[i] > max) max = arr[i];
                //Phân loại dấu của phần tử
                if (arr[i] < 0) demAm++;
                else if (arr[0] > 0) demDuong++;
                else demZero++;
            }
            //Ép kiểu sang double để không bị làm tròn phần nguyên
            double tbc = (double)tong / n;
            //in kết quả
            Console.WriteLine($"Tong: {tong}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Trung binh cong: {tbc}");
            Console.WriteLine($"So phan tu am: {demAm}; duong: {demDuong}; bang 0: {demZero}");
            //Đảo mảng: con trỏ left bắt đầu từ vị trí đầu mảng
            int left = 0;
            //Con trỏ right bắt đầu từ vị trí cuối mảng
            int right = n - 1;
            //Lặp khi 2 con trỏ chưa gặp/ vượt nhau
            while (left < right)
            {
                //Lưu tạm giá trị left vào temp để không bị ghi đè mất
                int temp = arr[left];
                //Gán giá trị bên phải vào ô bên trái
                arr[left] = arr[right];
                //Gán giá trị tạm vào ô bên phải (hoàn tất hoán vị 1 cặp
                arr[right] = temp;
                //Dịch con trỏ trái tiến sang 1 vị trí
                left++;
                //Dịch con trỏ phải lùi sang 1 vị trí
                right--;
            }
            //In mảng sau khi đảo
            Console.Write("Mang sau khi dao tai cho: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
