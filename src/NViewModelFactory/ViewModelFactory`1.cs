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
	/// <summary>
	/// 	Responsible for defining the base implementation for types implementing factories for the creation of viewmodels that - are unaffected by the deployment environment. - do *not* require the supply of a typed dto to the Create method.
	/// </summary>
	public abstract class ViewModelFactory<TModel> : IViewModelFactory<TModel>
		where TModel : IServiceLocatorInstantiatedViewModel, new()
	{
		/// <summary>
		/// 	Defines the the factory method for the construction of the view model constructed by the factory.
		/// </summary>
		public abstract TModel CreateModel();
	}
}