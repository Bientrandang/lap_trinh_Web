# BÀI 1: QUẢN LÝ SINH VIÊN BẰNG OOP

Dự án ứng dụng Console bằng ngôn ngữ C# nhằm thực hành kiến thức Lập trình hướng đối tượng (OOP) và thao tác quản lý danh sách sinh viên.

---

## 🎯 1. Mục tiêu kiến thức

Luyện tập và áp dụng các khái niệm core trong C# & OOP:
- **Class & Object:** Định nghĩa lớp `Student` và tạo đối tượng.
- **Constructor:** Khởi tạo thông tin cho sinh viên.
- **Property:** Đóng gói các thuộc tính getters/setters.
- **Encapsulation:** Đảm bảo tính đóng gói dữ liệu.
- **Static Member:** Quản lý đếm số lượng hoặc hỗ trợ xử lý chung.
- **Nullable Reference Types:** Xử lý các giá trị có thể null an toàn.
- **List<T>:** Dùng danh sách động để lưu trữ và quản lý tập hợp sinh viên.

---

## 📋 2. Thông tin sinh viên

Mỗi sinh viên trong hệ thống bao gồm các thông tin:
- **Mã sinh viên** (`StudentId`)
- **Họ tên** (`FullName`)
- **Ngày sinh** (`DateOfBirth`)
- **Giới tính** (`Gender`)
- **Email** (`Email`)
- **Số điện thoại** (`PhoneNumber`)
- **Ngành học** (`Major`)
- **Điểm trung bình** (`Gpa`)
- **Trạng thái học tập** (`Status`)

---

## ⚙️ 3. Chức năng hệ thống

1. **Thêm sinh viên:** Nhập thông tin sinh viên mới và lưu vào danh sách.
2. **Hiển thị danh sách:** Xuất toàn bộ danh sách sinh viên ra màn hình.
3. **Tìm sinh viên theo mã:** Tìm kiếm chính xác theo Mã sinh viên.
4. **Tìm gần đúng theo họ tên:** Tìm kiếm sinh viên theo từ khóa trong tên.
5. **Cập nhật sinh viên:** Sửa thông tin của sinh viên dựa trên Mã sinh viên.
6. **Xóa sinh viên:** Xóa thông tin sinh viên khỏi danh sách.
7. **Sắp xếp theo họ tên:** Sắp xếp danh sách sinh viên theo thứ tự bảng chữ cái.
8. **Sắp xếp theo điểm trung bình:** Sắp xếp danh sách theo GPA tăng/giảm dần.
9. **Hiển thị sinh viên giỏi:** Lọc danh sách các sinh viên có điểm TB từ $8.0$ trở lên.
10. **Hiển thị sinh viên thủ khoa:** Tìm và hiển thị sinh viên có điểm TB cao nhất.

---

## 🚀 Hướng dẫn chạy chương trình

1. Clone repository về máy:
   ```bash
   git clone [https://github.com/Bientrandang/lap_trinh_Web.git](https://github.com/Bientrandang/lap_trinh_Web.git)
