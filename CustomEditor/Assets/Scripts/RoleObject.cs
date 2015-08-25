using UnityEngine;
using System.Collections;
using PLY.CustomAttribute;

[System.Serializable]
public class Skill{
	[CustomLabel("技能ID")]
	public int		_id;

	[CustomLabel("角色ID")]
	public string	_name;

	[CustomLabel("冷却时间")]
	public float	_cool_down_duration;
}


public class RoleObject : ScriptableObject {
	[CustomLabel("角色ID")]
	public int		_id;

	[CustomLabel("角色名称")]
	public string	_name;
	
	public Skill[]	_skill_list;

}
