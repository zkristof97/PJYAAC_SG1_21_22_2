using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJYAAC_SG1_21_22_2.Models.Models
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public List<string> ExceptionMessages { get; set; }

        public ApiResult(bool isSuccess)
        {
            IsSuccess = isSuccess;
            ExceptionMessages = new List<string>();
        }
    }
}
