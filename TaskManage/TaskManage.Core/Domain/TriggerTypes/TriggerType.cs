
namespace TaskManage.Core.Domain.TriggerTypes
{
    //觸發器類型
   public class TriggerType
    {
        private readonly string _code;
        public TriggerType(string code)
        {
            _code = code;
        }
        public string Code
        {
            get { return _code; }
        }
    }
}
