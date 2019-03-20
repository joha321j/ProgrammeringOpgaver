using System.Collections.Generic;

namespace Dictionary
{
    class MemberController
    {
        private readonly Dictionary<int, Member> _actives = new Dictionary<int, Member>();
        private readonly Dictionary<int, Member> _passives = new Dictionary<int, Member>();

        public void AddMember(MemberType memberType, Member m)
        {

            if (m == null)
            {
                return;
            }
            //Pre: "m" is a member-object, "m.Id" must not be present in "actives" or "passives"
            //Post: "m" is added to either "actives" or "passives" - which one is determined by "memberType"
            switch (memberType)
            {
                case MemberType.active:
                    _actives.Add(m.Id, m);
                    break;
                case MemberType.passive:
                    _passives.Add(m.Id, m);
                    break;
            }
        }

        public bool IdAlreadyUsed(int id)
        {
            //Pre: None
            //Post: Returns true if "id" is used as "Id" by any object in either "actives" or "passives"
            bool containsKey = _passives.ContainsKey(id);
            if (containsKey)
            {
                return true;
            }

            containsKey = _actives.ContainsKey(id);
            return containsKey;
        }

        public IEnumerable<string> GetMembers()
        {
            //Pre: None
            //Post: A list containing all members from "actives" and "passives" is returned

            List<Member> list = new List<Member>();
            foreach (KeyValuePair<int, Member> member in _actives)
            {
                list.Add(member.Value);
            }

            foreach (KeyValuePair<int, Member> member in _passives)
            {
                list.Add(member.Value);
            }
            return list.ConvertAll(x => x.ToString());
        }

        public bool DeleteMember(int id)
        {

            //Pre: None
            //Post: No object having "id" as "Id" exist in either "actives" or "passives"
            //      If an object was removed from either "actives" or "passives" "True" is returned
            //      If no object was removed from either "actives" or "passives" "False" is returned

            if (_actives.ContainsKey(id))
            {
                return _actives.Remove(id);
            }

            return _passives.ContainsKey(id) && _passives.Remove(id);
        }
    }
}

