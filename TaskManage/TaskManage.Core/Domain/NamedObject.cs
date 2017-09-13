
namespace TaskManage.Core.Domain
{
  public  class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

      protected string Name { get; set; }
    }
}
