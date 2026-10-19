using System;
using System.Collections.Generic;
using System.Text;

namespace CTDLGT_Buoi02_BoSung_31251022054.Bai4
{
    internal class bai4
    {
        public class DynamicArray<T>
        {
            private T[] items; // Mảng lưu trữ bên dưới
            public int Count { get; private set; } // Số phần tử hợp lệ
            public int Capacity => items.Length;   // Sức chứa vật lý

            // Khởi tạo mảng động với dung lượng ban đầu (mặc định = 4)
            public DynamicArray(int initialCapacity = 4)
            {
                items = new T[initialCapacity];
                Count = 0;
            }
            // Tự động nhân đôi sức chứa khi mảng đầy
            private void EnsureCapacity()
            {
                if (Count >= items.Length)
                {
                    int newCap = items.Length == 0 ? 4 : items.Length * 2;
                    Console.WriteLine($"[Tràn mảng] Mở rộng Capacity: {items.Length} -> {newCap}");

                    T[] newArray = new T[newCap];
                    for (int i = 0; i < Count; i++)
                    {
                        newArray[i] = items[i]; // Sao chép thủ công sang mảng mới
                    }
                    items = newArray;
                }
            }
            // Thêm phần tử mới vào cuối mảng (Amortized O(1))
            public void Add(T item)
            {
                EnsureCapacity();
                items[Count] = item;
                Count++;
            }
            // Bộ chỉ mục (Indexer) truy xuất O(1) có bắt ngoại lệ ngoài phạm vi
            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= Count)
                        throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số ngoài phạm vi hợp lệ!");
                    return items[index];
                }
                set
                {
                    if (index < 0 || index >= Count)
                        throw new ArgumentOutOfRangeException(nameof(index), "Chỉ số ngoài phạm vi hợp lệ!");
                    items[index] = value;
                }
            }
            // Tiện ích in mảng
            public void InMang()
            {
                Console.Write("Mảng: [");
                for (int i = 0; i < Count; i++)
                    Console.Write(items[i] + (i < Count - 1 ? ", " : ""));
                Console.WriteLine($"] | Count = {Count} | Capacity = {Capacity}");
            }
        }
        class Program
        {
            static void Main()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                //khởi tạo một đối tượng mảng động mới chứa các số nguyên, với sức chứa ban đầu là 4 ô nhớ
                DynamicArray<int> da = new DynamicArray<int>(4);
                // 1. Thêm 10 phần tử để kích hoạt mở rộng dung lượng
                for (int i = 1; i <= 10; i++)
                {
                    da.Add(i);
                    Console.WriteLine($"Thêm {i,2} -> Count = {da.Count,2}, Capacity = {da.Capacity,2}");
                }
                da.InMang();
                // 2. Thao tác Indexer hợp lệ
                Console.WriteLine($"\nĐọc da[3] = {da[3]}");
                da[3] = 999;
                Console.WriteLine($"Gán da[3] = 999 -> Đọc lại: da[3] = {da[3]}");
                // 3. Bắt ngoại lệ Indexer không hợp lệ
                try
                {
                    Console.Write("Truy xuất chỉ số âm da[-1]: ");
                    int x = da[-1];
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Bắt lỗi thành công: " + ex.ParamName);
                }

                try
                {
                    Console.Write($"Truy xuất ô đệm da[{da.Count}]: ");
                    int y = da[da.Count];
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine("Bắt lỗi thành công: " + ex.ParamName);
                }
            }
        }
    }
}