
using System;
using System.Linq;
using System.Windows.Forms;

namespace QUANLYCUAHANGDIENTHOAI
{
    public static class AuthHelper
    {
        // Lưu thông tin người dùng đang đăng nhập trên toàn hệ thống
        public static string MaNV { get; set; } = "";
        public static string HoTen { get; set; } = "";
        public static string VaiTro { get; set; } = ""; // "Quản lý", "Nhân viên bán hàng", "Nhân viên kho/kỹ thuật"

        // Hằng số tên 3 vai trò chuẩn trong Database
        public const string QUAN_LY = "Quản lý";
        public const string BAN_HANG = "Nhân viên bán hàng";
        public const string KHO_KY_THUAT = "Nhân viên kho/kỹ thuật";

        /// <summary>
        /// Hàm kiểm tra quyền tương đương [Authorize(Roles = "...")]
        /// Lưu ý: "Quản lý" luôn được phép truy cập vào mọi chức năng.
        /// </summary>
        public static bool CheckRole(params string[] allowedRoles)
        {
            if (string.IsNullOrEmpty(VaiTro))
            {
                MessageBox.Show("Phiên đăng nhập không hợp lệ. Vui lòng đăng nhập lại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Quản lý luôn có toàn quyền (Nhóm A + B + C + D)
            if (VaiTro.Equals(QUAN_LY, StringComparison.OrdinalIgnoreCase))
                return true;

            // Kiểm tra xem VaiTro hiện tại có nằm trong danh sách cho phép không
            foreach (string role in allowedRoles)
            {
                if (VaiTro.Equals(role, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            MessageBox.Show($"Từ chối truy cập!\nChức năng này không dành cho vai trò [{VaiTro}].", "Phân quyền hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return false;
        }
    }
}