using System;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class GroupAttribute : Attribute, IEquatable<GroupAttribute>
{
	public readonly string group;
	public readonly int order;

	public GroupAttribute(string @group, int order = 0)
	{
		this.group = @group;
		this.order = order;
	}

	public bool Equals(GroupAttribute other)
	{
		if (ReferenceEquals(null, other))
		{
			return false;
		}

		if (ReferenceEquals(this, other))
		{
			return true;
		}

		return base.Equals(other) && @group == other.@group;
	}

	public override bool Equals(object obj)
	{
		if (ReferenceEquals(null, obj))
		{
			return false;
		}

		if (ReferenceEquals(this, obj))
		{
			return true;
		}

		if (obj.GetType() != this.GetType())
		{
			return false;
		}

		return Equals((GroupAttribute)obj);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(base.GetHashCode(), @group);
	}
}