
namespace TaskManage.Core.Domain
{
  public  class JobType
    {
        public string FullName { get; set; }
        public string AssemblyName { get; set; }
        public override string ToString()
        {
            return FullName;
        }
    }
}
