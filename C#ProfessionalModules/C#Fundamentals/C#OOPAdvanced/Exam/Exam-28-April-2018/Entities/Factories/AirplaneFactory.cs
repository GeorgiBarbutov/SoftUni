namespace Travel.Entities.Factories
{
	using Contracts;
	using Airplanes.Contracts;
    using System.Reflection;
    using System;
    using Travel.Core;

    public class AirplaneFactory : IAirplaneFactory
	{
		public IAirplane CreateAirplane(string type)
		{
            Assembly assembly = Assembly.GetCallingAssembly();

            Type airplaneType = assembly.GetType(type);

            //if (airplaneType == null)
            //{
            //    throw new ArgumentException(Constants.AIRPLANE_TYPE_NOT_FOUND);
            //}
            //if (!typeof(IAirplane).IsAssignableFrom(airplaneType))
            //{
            //    throw new ArgumentException(Constants.AIRPLANE_TYPE_NOT_ASSIGNABLE);
            //}

            IAirplane airplane = (IAirplane)Activator.CreateInstance(airplaneType);

            return airplane;
        }
	}
}