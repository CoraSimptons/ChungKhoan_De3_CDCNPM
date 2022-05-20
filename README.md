**Đề tài**:
- Bảng giá trực tuyến: Khi có lệnh đặt làm thay đổi dữ liệu thì ngay lập tức
chuyển dữ liệu đó tới client.

- Cơ sở dữ liệu: CHUNGKHOAN
- Các tables:
   + LENHDAT
	-- Chứa các lệnh đặt mua/bán cổ phiếu của các nhà đầu tư
	-- Các trường: Id, Macp, Ngaydat, Loaigd (Mua, Bán), Loailenh (LO: khớp lệnh liên tục), Soluong, Giadat, Trangthailenh (Chờ khớp, Khớp lệnh 1 phần, Khớp hết)
   + LENHKHOP
	-- Chứa các lệnh khớp khi thoả qui tắc khớp lệnh
	-- Các trường: Idkhop, Ngaykhop, Soluongkhop, Giakhop, Idlengdat
   + BANGGIATRUCTUYEN
	-- Lưu các thông tin, sau đó dùng SQL Dependency để tạo 1 kết nối theo dõi biến động của bảng này
	-- Hiển thị lên web gồm 16 cột: Mack, 6 cột bên mua, khối lượng khớp lệnh mới nhất, giá khớp mới nhất, 6 cột bên bán, tổng khối lượng khớp trong phiên
	-- Giá bán và mua thì sẽ khớp theo giá bán nếu lệnh gửi vào là mua và ngược lại
- Chú ý:
   + Không sửa dữ liệu trong bảng BANGGIATRUCTUYEN nhưng phải cập nhật trong bảng lệnh đặt và lệnh khớp

_Để làm được đề tài cần tìm hiểu 3 vấn đề sau:_
   + Trigger là gì?
   + Dịch vụ SQL Broker trong SQL Server và cách hoạt động?
   + SQL Dependency trong C# là gì?





