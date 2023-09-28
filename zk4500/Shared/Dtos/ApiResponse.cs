using System.Collections.Generic;

namespace zk4500.Shared.Dtos
{
    public class ApiResponse<T>
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public virtual List<T> Datas { get; set; }

    }
}
