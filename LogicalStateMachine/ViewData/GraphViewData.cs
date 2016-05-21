using DT;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DT.GameEngine {
  [Serializable]
  public class GraphViewData {
    // PRAGMA MARK - Public Interface
    public NodeViewData LoadViewDataForNode(Node node) {
      NodeViewData viewData = this.CachedNodeViewDataMapping.SafeGet(node.Id);
      if (viewData == null) {
        viewData = this.MakeNewNodeViewData(node);
      }
      return viewData;
    }


    // PRAGMA MARK - Internal
    [SerializeField] private List<NodeViewData> _nodeViewDatas = new List<NodeViewData>();

    private Dictionary<NodeId, NodeViewData> _cachedNodeViewDataMapping;
    private Dictionary<NodeId, NodeViewData> CachedNodeViewDataMapping {
      get {
        if (this._cachedNodeViewDataMapping == null) {
          this._cachedNodeViewDataMapping = new Dictionary<NodeId, NodeViewData>();
          foreach (NodeViewData nodeViewData in this._nodeViewDatas) {
            this._cachedNodeViewDataMapping[nodeViewData.nodeId] = nodeViewData;
          }
        }

        return this._cachedNodeViewDataMapping;
      }
    }

    private void ClearCached() {
      this._cachedNodeViewDataMapping = null;
    }

    private NodeViewData MakeNewNodeViewData(Node node) {
      NodeViewData newViewData = new NodeViewData(node);
      this._nodeViewDatas.Add(newViewData);
      this.ClearCached();
      return newViewData;
    }
  }
}