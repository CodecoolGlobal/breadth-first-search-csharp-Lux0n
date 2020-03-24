using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_c_sharp
{
    class BreadthFirstSearch
    {
        private readonly List<UserNode> users;
        private UserNode v;
        private Queue<UserNode> queue = new Queue<UserNode>();
        private Dictionary<int, bool> discovery = new Dictionary<int, bool>();
        private Dictionary<int, int> parents = new Dictionary<int, int>();

        public BreadthFirstSearch(List<UserNode> users)
        {
            this.users = users;
            Setup();
        }

        void Setup()
        {
            discovery.Clear();
            parents.Clear();
            foreach(UserNode user in users)
            {
                discovery.Add(user.Id, false);
                parents.Add(user.Id, -1);
            }
            //discovery[v.Id] = true;
            //queue.Enqueue(v);
        }

        public int MinDistance(UserNode a, UserNode b)
        {
            v = a;
            discovery[v.Id] = true;
            queue.Enqueue(v);
            while(queue.Count > 0)
            {
                v = queue.Dequeue();
                foreach(UserNode child in v.Friends)
                {
                    if (!discovery[child.Id])
                    {
                        discovery[child.Id] = true;
                        queue.Enqueue(child);
                        parents[child.Id] = v.Id;
                        if(child.Id == b.Id)
                        {
                            return CountDistance(a, b);
                        }
                    }
                }
                //dist--;
            }

            return 0;
        }

        public HashSet<UserNode> FriendsOfFriends(UserNode a, int distance)
        {
            /*
            v = a;
            discovery[v.Id] = true;
            int dist = distance;
            List<UserNode> result = new List<UserNode>();
            queue.Enqueue(v);
            while(dist > 0 || queue.Count > 0)
            {
                v = queue.Dequeue();
                foreach (UserNode child in v.Friends)
                {
                    if (!discovery[child.Id])
                    {
                        discovery[child.Id] = true;
                        queue.Enqueue(child);
                        parents[child.Id] = v.Id;
                        result.Add(child);
                    }
                }
                dist--;
            }
            */
            HashSet<UserNode> result = new HashSet<UserNode>();
            foreach(UserNode user in users)
            {
                if(MinDistance(a, user) < distance && !result.Contains(user))
                {
                    result.Add(user);
                }
            }

            return result;
        }

        public List<UserNode> ShortestPath(UserNode a, UserNode b)
        {
            return null;
        }

        int CountDistance(UserNode a, UserNode b)
        {
            int distance = 0;
            int current = b.Id;
            while (true)
            {
                if (parents[current] == -1)
                {
                    return -1;
                }
                else                 
                {
                    distance++;
                    if (parents[current] == a.Id)
                    {
                        return distance;
                    }
                    else
                    {
                        current = parents[current];
                    } 
                }
                
            }
        }

    }
}
