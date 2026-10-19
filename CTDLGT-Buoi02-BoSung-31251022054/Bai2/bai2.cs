using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251022054.Bai2
{
    internal class bai2 //Viết hai phương thức Insert và RemoveAt thao tác trên mảng có vùng trống. Biến count cho biết số phần tử hợp lệ; data.Length cho biết số ô đã cấp phát.
    {
        // Phương thức chèn giá trị value vào vị trí index
        static void Insert(int[] data, ref int count, int index, int value)
        {
            // Kiểm tra xem mảng còn ô trống hay không
            if (count >= data.Length)
            {
                throw new InvalidOperationException("Mảng đã đầy sức chứa, không thể chèn thêm!");
            }
            // Kiểm tra chỉ số chèn hợp lệ trong đoạn [0, count]
            if (index < 0 || index > count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số index chèn không hợp lệ!");
            }
            // Dịch lùi các phần tử từ phải sang trái để giải phóng vị trí index
            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            // Ghi giá trị mới vào ô trống
            data[index] = value;
            // Tăng số lượng phần tử hợp lệ
            count++;
        }
        // Phương thức xóa phần tử tại vị trí index
        static void RemoveAt(int[] data, ref int count, int index)
        {
            // Kiểm tra chỉ số xóa hợp lệ trong đoạn [0, count - 1]
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số index xóa không hợp lệ!");
            }
            // Dịch cuốn chiếu các phần tử từ trái sang phải đè lên vị trí bị xóa
            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }
            // Giảm số lượng phần tử hợp lệ
            count--;
        }
        // Hàm tiện ích in các phần tử hợp lệ trong mảng
        static void InMang(int[] data, int count)
        {
            Console.Write("Mảng hiện tại: ");
            for (int i = 0; i < count; i++)
            {
                Console.Write(data[i] + (i < count - 1 ? ", " : "")); //điều kiện ? gtri nếu đúng : gtri nếu sai
            }
            Console.WriteLine($", count = {count}, Dung lượng tối đa = {data.Length}");
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Khởi tạo mảng có sức chứa lớn hơn số phần tử ban đầu (ví dụ: sức chứa 20 ô)
            int[] data = new int[20];
            //Nhập số lượng phần tử ban đầu
            Console.Write("Nhập số lượng phần tử ban đầu: ");
            int count = int.Parse(Console.ReadLine());
            //Nhập các giá trị ban đầu trên 1 dòng
            Console.Write($"Nhập {count} phần tử ban đầu: ");
            string[] inputs = Console.ReadLine().Split(' ');
            for (int i = 0; i < count; i++)
            {
                data[i] = int.Parse(inputs[i]);
            }
            InMang(data, count);
            //Nhập thao tác chèn
            Console.WriteLine("THỰC HIỆN CHÈN PHẦN TỬ");
            try
            {
                Console.Write("Nhập vị trí muốn chèn: ");
                int insertIndex = int.Parse(Console.ReadLine()!);

                Console.Write("Nhập giá trị muốn chèn: ");
                int insertValue = int.Parse(Console.ReadLine()!);

                Insert(data, ref count, insertIndex, insertValue);
                Console.WriteLine("-> Chèn thành công!");
                InMang(data, count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("LỖI: " + ex.Message);
            }
            //Nhập thao tác xóa
            Console.WriteLine("THỰC HIỆN XÓA PHẦN TỬ");
            try
            {
                Console.Write("Nhập vị trí muốn xóa: ");
                int removeIndex = int.Parse(Console.ReadLine()!);

                RemoveAt(data, ref count, removeIndex);
                Console.WriteLine("-> Xóa thành công!");
                InMang(data, count);
            }
            catch (Exception ex)
            {
                Console.WriteLine("LỖI: " + ex.Message);
            }
        }
    }
}
