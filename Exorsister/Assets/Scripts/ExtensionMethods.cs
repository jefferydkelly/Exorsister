using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{

	/// <summary>
	/// Returns a random element from the list.
	/// </summary>
	/// <returns>A random element from the list.</returns>
	/// <param name="list">The list.</param>
	/// <typeparam name="T">The 1st type parameter.</typeparam>
	public static T RandomElement<T>(this List<T> list)
	{
		return list[Random.Range(0, list.Count - 1)];
	}

	/// <summary>
	/// Determines if the float is between min and max.  (Exclusive)
	/// </summary>
	/// <returns><c>true</c>, if the value is between min and max, <c>false</c> otherwise.</returns>
	/// <param name="f">The value to be checked.</param>
	/// <param name="min">The minimum value.</param>
	/// <param name="max">The maximum value.</param>
	public static bool BetweenEx(this float f, float min, float max)
	{
		return f > min && f < max;
	}

	/// <summary>
	/// Determines if the float is between min and max.
	/// </summary>
	/// <returns><c>true</c>, if the value is between min and max, <c>false</c> otherwise.</returns>
	/// <param name="f">The value to be checked.</param>
	/// <param name="min">The minimum value.</param>
	/// <param name="max">The maximum value.</param>
	public static bool Between(this float f, float min, float max)
	{
		return f >= min && f <= max;
	}

	/// <summary>
	/// Converts the angle from radians to degrees and returns it.
	/// </summary>
	/// <returns>The angle in radians.</returns>
	/// <param name="f">The angle in degrees.</param>
	public static float ToDegrees(this float f)
	{
		return f * Mathf.Rad2Deg;
	}

	/// <summary>
	/// Converts the angle from degrees to radians and returns it.
	/// </summary>
	/// <returns>The angle in degrees.</returns>
	/// <param name="f">The angle in degrees.</param>
	public static float ToRadians(this float f)
	{
		return f * Mathf.Deg2Rad;
	}

	/// <summary>
	/// Rounds to nearest multiple of the given value.
	/// </summary>
	/// <returns>The given float rounded to the nearet multiple of val.</returns>
	/// <param name="f">The float to be rounded.</param>
	/// <param name="val">The value whose multiple f will be rounded to.</param>
	public static float RoundToNearest(this float f, float val)
	{
		return Mathf.Round(f / val) * val;
	}

	/// <summary>
	/// Returns a new Vector3 with the given X value and YZ values that match the Vector3.
	/// </summary>
	/// <returns>The x.</returns>
	/// <param name="vec">Vec.</param>
	/// <param name="x">The x coordinate.</param>
	public static Vector3 SetX(this Vector3 vec, float x)
	{
		return new Vector3(x, vec.y, vec.z);
	}

	/// <summary>
	/// Sets the y.
	/// </summary>
	/// <returns>The y.</returns>
	/// <param name="vec">Vec.</param>
	/// <param name="y">The y coordinate.</param>
	public static Vector3 SetY(this Vector3 vec, float y)
	{
		return new Vector3(vec.x, y, vec.z);
	}

	/// <summary>
	/// Sets the z.
	/// </summary>
	/// <returns>The z.</returns>
	/// <param name="vec">Vec.</param>
	/// <param name="z">The z coordinate.</param>
	public static Vector3 SetZ(this Vector3 vec, float z)
	{
		return new Vector3(vec.x, vec.y, z);
	}

	/// <summary>
	/// Sets the x.
	/// </summary>
	/// <returns>The x.</returns>
	/// <param name="vec">Vec.</param>
	/// <param name="x">The x coordinate.</param>
	public static Vector2 SetX(this Vector2 vec, float x)
	{
		return new Vector2(x, vec.y);
	}

	/// <summary>
	/// Sets the y.
	/// </summary>
	/// <returns>The y.</returns>
	/// <param name="vec">Vec.</param>
	/// <param name="y">The y coordinate.</param>
	public static Vector2 SetY(this Vector2 vec, float y)
	{
		return new Vector2(vec.x, y);
	}
}
