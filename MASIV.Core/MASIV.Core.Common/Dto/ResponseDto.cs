using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MASIV.Core.Common.Dto
{
    public class BaseResponseDto
    {
        public BaseResponseDto()
        {
            Errors = new List<string>();
        }

        public string Message { get; set; }

        public long Result { get; set; }

        public bool IsSuccessful { get; set; }

        public int Status { get; set; }

        public List<string> Errors { get; set; }

        public string ErrorsToString()
        {
            Errors ??= new List<string>();
            string result = string.Join(Environment.NewLine, Errors.ToArray());
            return result;
        }
    }
    public class ResponseDto<T> : BaseResponseDto
    {
        public T Data { get; set; }
    }
}
