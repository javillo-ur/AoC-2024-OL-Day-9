﻿Console.WriteLine(File.ReadAllLines("input.txt").Select(line => line.Aggregate((new List<(int,int)>(), 0, true), (curr, it) => curr.Item3 ? ([..curr.Item1, (int.Parse(it+""), curr.Item2)], curr.Item2+1, false) : ([..curr.Item1, (int.Parse(it+""), -1)], curr.Item2, true))).Select(list => (System.Collections.Immutable.ImmutableList.ToImmutableList(list.Item1), list.Item2)).Select(list => Enumerable.Range(0, list.Item2).Reverse().Aggregate(list.Item1, (curr, it) => new List<(System.Collections.Immutable.ImmutableList<(int,int)>,int)>(){(curr, curr.IndexOf(curr.First(t => t.Item2 == it)))}.Select(curraux => curraux.Item1.Where((t,ind) => ind < curraux.Item2 && t.Item2 == -1 && t.Item1 >= curraux.Item1[curraux.Item2].Item1).Select(t => (t, curr.IndexOf(t))).Select(t => curr[t.Item2].Item1 == curr[curraux.Item2].Item1 ? curr.RemoveAt(curraux.Item2).RemoveAt(t.Item2).Insert(t.Item2, (t.t.Item1, it)).Insert(curraux.Item2, (t.t.Item1, -1)) : curr.RemoveAt(curraux.Item2).RemoveAt(t.Item2).Insert(t.Item2, (t.t.Item1 - curr[curraux.Item2].Item1, -1)).Insert(t.Item2, (curr[curraux.Item2].Item1, it)).Insert(curraux.Item2+1, (curr[curraux.Item2].Item1, -1))).FirstOrDefault(t => true, curr)).First())).Select(list => list.Aggregate<(int,int),List<long>>([], (curr, it) => [..curr, ..Enumerable.Range(0, it.Item1).Select(t => it.Item2)])).Select(list => list.Select((i,pos) => i != -1 ? i * pos : 0)).Sum(t => t.Sum()));