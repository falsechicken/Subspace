//
//  ISubspaceInterface.cs
//
//  Author: False_Chicken
//  Contact: jmdevsupport@gmail.com
//
//  Copyright (c) 2015 False_Chicken
//
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
//
using System;

namespace FC.Libs.Subspace
{
	/**
	 * Plugins must implement this interface to use Subspace.
	 */
	public interface ISubspaceInterface {

		/**
		 * Called when a message is sent along a Subspace channel a plugin has subscribed to. Return
		 * true to prevent the message from propagating further.
		 */
		Boolean ReceiveMessage(SubspaceMessage _message);
	}
}

