﻿// Copyright 2012, Ben Aston (ben@bj.ma).
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
	/// 	Responsible for defining the signature for methods that instantiate view models.
	/// </summary>
	/// <typeparam name="TModel"> The type of view model instantiated by the method. Must have default constructor. </typeparam>
	/// <typeparam name="TDto"> Type of the dto used to pass information into the delegate. </typeparam>
	/// <returns> An instantiated view model based upon logic contained within the delegate implementation. </returns>
	public delegate TModel ViewModelCreatorDelegate<out TModel, in TDto>(TDto dto = null)
		where TModel : IServiceLocatorInstantiatedViewModel, new() where TDto : class;
}