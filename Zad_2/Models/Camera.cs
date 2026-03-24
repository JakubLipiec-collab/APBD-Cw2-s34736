namespace Zad_2.Models;

public class Camera : Equipment
{
    public bool IsVideoCapable { get; private set; }
    public string Resolution { get; private set; }
    
    public Camera(string name, bool isVideoCapable, string resolution) : base(name)
    {
        IsVideoCapable = isVideoCapable;
        Resolution = resolution;
    }
}