namespace PortVeederRootGaugeSim.IO
{
    interface IProtocol
    {
        // Created to take advantage of polymorphism for the server classes and ensure parse is available
        string Parse(string toParse);
    }
}
