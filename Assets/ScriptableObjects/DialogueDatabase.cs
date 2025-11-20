using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Dialogue/DialogueDatabase")]
public class DialogueDatabase : ScriptableObject
{
    public List<DialogueNode> Nodes = new();

    private Dictionary<string, DialogueNode> _lookup;

    private void BuildNodeDictionary()
    {
        if (_lookup != null) return;
        _lookup = new Dictionary<string, DialogueNode>();

        foreach (var node in Nodes)
        {
            _lookup.Add(node.NodeId, node);
        }
    }

    public DialogueNode GetNode(string id)
    {
        if (string.IsNullOrEmpty(id)) return null;
        BuildNodeDictionary();
        _lookup.TryGetValue(id, out var node);
        return node;
    }
}
