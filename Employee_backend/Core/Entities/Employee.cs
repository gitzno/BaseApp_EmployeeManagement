using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.NewAttribute;

namespace Core.Entities
{
    public partial class Employee
    {
        [Identification]
        public Guid EmployeeId { get; set; }
        [Required(ErrorMessage = "Không được phép để trống")]
        [MaxLength(20, ErrorMessage = "Độ dài không được quá 20")]
        public string EmployeeCode { get; set; }

        [Required(ErrorMessage = "Không được phép để trống")]
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }

        public string IdentityNumber { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string? IdentityPlace { get; set; }

        //[Required(ErrorMessage = "Không được phép để trống")]
        //[EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }


        public string? PhoneNumber { get; set; }
        public string? PhoneNumberFixed { get; set; }

        public string? BankAccount { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }
        public string? BankAddress { get; set; }

        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Phòng ban
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// chức vụ
        /// </summary>
        public Guid? PositionId { get; set; }
        //public string? AvatarLink { get; set; }

        //public virtual Department Department { get; set; }
        //public virtual Position Position { get; set; }
    }
}

