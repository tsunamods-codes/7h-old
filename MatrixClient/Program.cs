using System;
using Matrix;
using Matrix.Client;
namespace Client
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			MatrixClient client = new MatrixClient ("http://matrix.org");
			client.LoginWithPassword ("", "");
			MatrixUser user = client.GetUser ("");

		}
	}
}
