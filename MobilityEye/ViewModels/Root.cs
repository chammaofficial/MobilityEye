namespace MobilityEye.ViewModels
{
    public class Form
    {
        public string type { get; set; }
        public string label { get; set; }
        public List<string> options { get; set; }
    }

    public class Root
    {
        public List<Form> form { get; set; }
    }

}
