using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace _04LayeredCRUD.Infrastructure
{
    public class SimpleIocAsServiceLocator : SimpleIoc, IServiceLocator
    {
        public static SimpleIocAsServiceLocator Instance { get; private set; } = new SimpleIocAsServiceLocator();
    }
}
