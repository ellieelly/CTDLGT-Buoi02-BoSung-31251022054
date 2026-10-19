•	README ghi họ tên, mã số sinh viên, cách chạy, mô tả thuật toán, độ phức tạp và các ca kiểm thử.
Trần Võ Vân Khanh - 31251022054
# Cấu Trúc Dữ Liệu & Giải Thuật - Thực Hành Mảng (C#)
##Cách chạy chương trình
* Mở solution/thư mục dự án bằng **Visual Studio** (hoặc VS Code).
* Chọn bài cần chạy (hoặc đặt làm *Startup Project*).
* Nhấn **`Ctrl + F5`** (Start Without Debugging) hoặc gõ `dotnet run` trên Terminal để xem kết quả Console.
##Tóm tắt thuật toán & Độ phức tạp
| Bài tập | Nội dung chính | Thời gian | Bộ nhớ phụ |
| **Bài 1** | Thống kê số liệu (duyệt tuần tự) và đảo ngược mảng (Two Pointers). | $O(n)$ | $\Theta(1)$ |
| **Bài 2** | Thao tác dịch chuyển mảng tại chỗ để chèn (`Insert`) và xóa (`RemoveAt`). | $O(n)$ | $\Theta(1)$ |
| **Bài 3** | Quản lý `List<Student>` (thêm, xóa, tìm kiếm theo tên, thống kê điểm). | $O(n)$ | $\Theta(1)$ |
| **Bài 4** | Tự cài đặt `DynamicArray<T>`: nhân đôi dung lượng ($Capacity \times 2$) khi đầy, truy xuất Indexer $\Theta(1)$. | Khấu hao $O(1)$ | $\Theta(1)$ / $O(n)$ khi nhân đôi |
##Các ca kiểm thử tiêu biểu
* **Bài 1:** Kiểm thử với mảng thông thường, mảng chứa số âm/số 0, và trường hợp biên (mảng 1 phần tử, mảng toàn âm).
* **Bài 2:** 
  * Chèn `99` tại `index = 2` (dịch 3 phần tử).
  * Xóa phần tử tại `index = 1` (dịch 4 phần tử).
  * Bắt ngoại lệ `ArgumentOutOfRangeException` (chỉ số âm/vượt ngưỡng) và `InvalidOperationException` (khi mảng đầy).
* **Bài 3:** Thêm danh sách sinh viên chuẩn; chặn trùng mã `Id` và điểm ngoài đoạn $[0, 10]$; tìm kiếm tuyến tính không phân biệt hoa/thường; xóa theo mã.
* **Bài 4:** Khởi tạo $Capacity = 4$, thêm lần lượt 10 phần tử để kiểm tra 2 lần tự động mở rộng dung lượng ($4 \rightarrow 8 \rightarrow 16$); kiểm tra Indexer và bắt lỗi chỉ số ngoài phạm vi.
