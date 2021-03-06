﻿using DT;
using System.Collections;
﻿using UnityEngine;

namespace DT.GameEngine {
	public class GameInit : MonoBehaviour {
		// PRAGMA MARK - Internal
    void Awake() {
      this.InitializeGameOnAwake();
    }

		void Start() {
			this.InitializeGame();

      CoroutineWrapper.DoAfterFrame(() => {
        this.DelayedInitializeGame();
      });
		}

    protected virtual void InitializeGameOnAwake() {
      CoroutineWrapper.Initialize();
      DebugManager.Instance.EmptyInitialize();
    }

		protected virtual void InitializeGame() {}
    protected virtual void DelayedInitializeGame() {}
	}
}