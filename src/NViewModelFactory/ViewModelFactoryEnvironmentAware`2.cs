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

namespace Bjma.Utility.Web.ViewModelConstruction
{
	using System.Configuration;
	using NBasicExtensionMethod;
	using NViewModelFactory;

	public abstract class ViewModelFactoryEnvironmentAware<TModel, TDto> :
		IViewModelFactory<TModel, TDto> where TModel : IServiceLocatorInstantiatedViewModel, new()
	{
		private const string EnvironmentNameAppSettingsKey = "EnvironmentName";
		private const string LocalEnvironmentAppSettingsValue = "Local";
		private const string StagingEnvironmentAppSettingsValue = "Staging";
		private const string ReleaseEnvironmentAppSettingsValue = "Release";

		/// <summary>
		/// 	Performs invocation of the method corresponding to the current deployment environment.
		/// </summary>
		public TModel CreateModel(TDto dto) {
			switch (EnvironmentNameAppSettingsKey.AppSetting()) {
				case LocalEnvironmentAppSettingsValue:
					return CreateModelForLocal(dto);
				case StagingEnvironmentAppSettingsValue:
					return CreateModelForStaging(dto);
				case ReleaseEnvironmentAppSettingsValue:
					return CreateModelForRelease(dto);
				default:
					throw new ConfigurationErrorsException(EnvironmentNameAppSettingsKey + " app setting not found.");
			}
		}

		protected abstract TModel CreateModelForLocal(TDto dto);
		protected abstract TModel CreateModelForStaging(TDto dto);
		protected abstract TModel CreateModelForRelease(TDto dto);
	}

	///// <summary>
	///// Enables specification of a concrete type and base type to
	///// ensure view model compatibility.
	///// </summary>
	//public abstract class ViewModelFactoryWithBaseTypeDefinitionEnvironmentAware<TModel, TItem, TItemBase, TDto> :
	//    ViewModelFactoryEnvironmentAware<TModel, TDto>
	//    where TItem : TItemBase, IServiceLocatorInstantiatedViewModel, new()
	//    where TModel : IServiceLocatorInstantiatedViewModel
	//{
	//    private const string EnvironmentNameAppSettingsKey = "EnvironmentName";
	//    private const string LocalEnvironmentAppSettingsValue = "Local";
	//    private const string StagingEnvironmentAppSettingsValue = "Staging";
	//    private const string ReleaseEnvironmentAppSettingsValue = "Release";

	//    /// <summary>
	//    ///   Performs invocation of the method corresponding to the 
	//    ///   current deployment environment.
	//    /// </summary>
	//    public new TModel<TItem> CreateModel(TDto dto)
	//    {
	//        switch (EnvironmentNameAppSettingsKey.AppSetting())
	//        {
	//            case LocalEnvironmentAppSettingsValue:
	//                return CreateModelForLocal(dto);
	//            case StagingEnvironmentAppSettingsValue:
	//                return CreateModelForStaging(dto);
	//            case ReleaseEnvironmentAppSettingsValue:
	//                return CreateModelForRelease(dto);
	//            default:
	//                throw new ConfigurationErrorsException(EnvironmentNameAppSettingsKey + " app setting not found.");
	//        }
	//    }


	//}
}