// Copyright 2012, Ben Aston (ben@bj.ma).
// 
// This file is part of NViewModelFactory.
// 
// NViewModelFactory is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NViewModelFactory is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NViewModelFactory. If not, see <http://www.gnu.org/licenses/>.

namespace NViewModelFactory
{
	using System.Configuration;
	using NBasicExtensionMethod;

	/// <summary>
	/// 	Responsible for defining the base implementation for types implementing factories for the creation of viewmodels specific to deployment environments. Derived types used to retrieve the correct functionality to bind to the IOC container.
	/// </summary>
	/// <typeparam name="TModel"> The type of view model to be returned by the delegate. </typeparam>
	public abstract class ViewModelFactoryEnvironmentAware<TModel> :
		IViewModelFactory<TModel, NullDto> where TModel : IServiceLocatorInstantiatedViewModel, new()
	{
		private const string EnvironmentNameAppSettingsKey = "EnvironmentName";
		private const string LocalEnvironmentAppSettingsValue = "Local";
		private const string StagingEnvironmentAppSettingsValue = "Staging";
		private const string ReleaseEnvironmentAppSettingsValue = "Release";

		/// <summary>
		/// 	Performs invocation of the method corresponding to the current deployment environment.
		/// </summary>
		public TModel CreateModel(NullDto d) {
			switch (EnvironmentNameAppSettingsKey.AppSetting()) {
				case LocalEnvironmentAppSettingsValue:
					return CreateModelForLocal();
				case StagingEnvironmentAppSettingsValue:
					return CreateModelForStaging();
				case ReleaseEnvironmentAppSettingsValue:
					return CreateModelForRelease();
				default:
					throw new ConfigurationErrorsException(EnvironmentNameAppSettingsKey + " app setting not found.");
			}
		}

		protected abstract TModel CreateModelForLocal();
		protected abstract TModel CreateModelForStaging();
		protected abstract TModel CreateModelForRelease();
	}
}