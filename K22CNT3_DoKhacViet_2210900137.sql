CREATE DATABASE K22CNT3_DoKhacViet_22010900137_db;
USE K22CNT3_DoKhacViet_22010900137_db;

CREATE TABLE QUAN_TRI (
    Tai_khoan VARCHAR(50) PRIMARY KEY,
    Mat_khau VARCHAR(32),
    Trang_thai TINYINT
);

CREATE TABLE KHACH_HANG (
    MaKH INT PRIMARY KEY,
    Ho_ten VARCHAR(100),
    Tai_khoan VARCHAR(50) UNIQUE,
    Mat_khau VARCHAR(32),
    Dia_chi VARCHAR(200),
    Dien_thoai VARCHAR(30),
    Email VARCHAR(50),
    Ngay_sinh DATETIME,
    Ngay_cap_nhat DATETIME,
    Gioi_tinh TINYINT,
    Tich_diem INT DEFAULT 0,
    Trang_thai TINYINT
);

CREATE TABLE HINH_NEN (
    Ma_hinh_nen INT PRIMARY KEY,
    Ten_hinh_nen VARCHAR(100),
    Do_phan_giai_hinh_nen VARCHAR(50),
    Kich_thuoc_file INT,
    Ma_nguoi_tai_len VARCHAR(50),  
    FOREIGN KEY (Ma_nguoi_tai_len) REFERENCES QUAN_TRI(Tai_khoan) ON DELETE SET NULL
    
);

CREATE TABLE DANH_GIA (
    Ma_danh_gia INT PRIMARY KEY,
    Ma_thanh_vien INT,
    Ma_hinh_nen INT,
    So_sao_danh_gia TINYINT CHECK (So_sao_danh_gia BETWEEN 1 AND 5), 
    FOREIGN KEY (Ma_thanh_vien) REFERENCES KHACH_HANG(MaKH) ON DELETE CASCADE,
    FOREIGN KEY (Ma_hinh_nen) REFERENCES HINH_NEN(Ma_hinh_nen) ON DELETE CASCADE
);

-- Thêm d? li?u vào b?ng QUAN_TRI
INSERT INTO QUAN_TRI (Tai_khoan, Mat_khau, Trang_thai) VALUES 
('dokhacviet', 'vanpaul1234', 1),
('admin2', 'secure456', 1),
('admin3', 'admin789', 1),
('admin4', 'pass1234', 1),
('admin5', 'admin5678', 1);

-- Thêm d? li?u vào b?ng KHACH_HANG
INSERT INTO KHACH_HANG (MaKH, Ho_ten, Tai_khoan, Mat_khau, Dia_chi, Dien_thoai, Email, Ngay_sinh, Ngay_cap_nhat, Gioi_tinh, Tich_diem, Trang_thai) VALUES 
(1, 'Do Khac Viet', 'user1', 'userpassword1', 'Ha Dong, Ha Noi', '0967993092', 'dov28501@gmail.com', '2004-02-15', '2024-10-25' , 1, 100, 1),
(2, 'Tran Thi B', 'user2', 'userpassword2', '456 Le Lai, HN', '0987654321', 'user2@example.com', '1995-02-02', '2024-10-26', 0, 200, 1),
(3, 'Pham Minh C', 'user3', 'userpassword3', '789 Hai Ba Trung, DN', '0912345678', 'user3@example.com', '1988-03-03', '2024-10-27', 1, 150, 1),
(4, 'Le Van D', 'user4', 'userpassword4', '321 Tran Hung Dao, HCM', '0909876543', 'user4@example.com', '1992-04-04', '2024-10-28', 0, 250, 1),
(5, 'Hoang Thi E', 'user5', 'userpassword5', '654 Nguyen Van Cu, HN', '0934567890', 'user5@example.com', '1998-05-05', '2024-10-29', 1, 300, 1);

-- Thêm d? li?u vào b?ng HINH_NEN
INSERT INTO HINH_NEN (Ma_hinh_nen, Ten_hinh_nen, Do_phan_giai_hinh_nen, Kich_thuoc_file, Ma_nguoi_tai_len) VALUES 
(1, 'C?nh bi?n', '1920x1080', 204800, 'dokhacviet'),
(2, 'Thành ph? v? ?êm', '1920x1080', 150000, 'admin2'),
(3, 'Hình n?n v? tr?', '2560x1440', 300000, 'admin3'),
(4, 'Anime Girl', '1920x1080', 250000, 'admin4'),
(5, 'Ngh? thu?t tr?u t??ng', '1920x1080', 180000, 'admin5');

-- Thêm d? li?u vào b?ng DANH_GIA
INSERT INTO DANH_GIA (Ma_danh_gia, Ma_thanh_vien, Ma_hinh_nen, So_sao_danh_gia) VALUES 
(1, 1, 1, 5),  -- Do Khac Viet ?ánh giá C?nh bi?n 5 sao
(2, 2, 2, 4),  -- Tran Thi B ?ánh giá Thành ph? v? ?êm 4 sao
(3, 3, 3, 3),  -- Pham Minh C ?ánh giá Hình n?n v? tr? 3 sao
(4, 4, 4, 2),  -- Le Van D ?ánh giá Anime Girl 2 sao
(5, 5, 5, 5);  -- Hoang Thi E ?ánh giá Ngh? thu?t tr?u t??ng 5 sao

SELECT * FROM QUAN_TRI;
SELECT * FROM KHACH_HANG;
SELECT * FROM HINH_NEN;
SELECT * FROM DANH_GIA;

DROP TABLE IF EXISTS DANH_GIA;
DROP TABLE IF EXISTS HINH_NEN;
DROP TABLE IF EXISTS KHACH_HANG;
DROP TABLE IF EXISTS QUAN_TRI;
