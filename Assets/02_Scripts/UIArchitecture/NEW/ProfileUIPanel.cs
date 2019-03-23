﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;

/// <summary>
/// [Example]
/// This is a panel that shows the level
/// It contains references to SEVERAL ALTERNATIVES
/// [Example]
/// </summary>
public class ProfileUIPanel : MonoBehaviour
{
    /// <summary>
    /// Alternative A: Containers
    /// The class with the desired components must be used (_Text, _Icon, _Highlight, etc..)
    /// PROS: This alternative is useful for PREFABS
    /// PROS: Additional methods can be added to manage multiple parts
    /// CONS: It require a new class for each variation
    /// </summary>
    [Header("Level Containers")]
    [SerializeField] private LevelUIContainer_Text _levelTextContainer;
    [SerializeField] private LevelUIContainer_Icon _levelIconContainer;
    [SerializeField] private LevelUIContainer_Icon_Text _levelIconTextContainer;
    [SerializeField] private LevelUIContainer_Highlight _levelHighlightContainer;
    [SerializeField] private LevelUIContainer_Highlight_Text _levelHighlightTextContainer;
    [SerializeField] private LevelUIContainer_Highlight_Icon _levelHighlightIconContainer;
    [SerializeField] private LevelUIContainer_Full _levelFullContainer;

    /// <summary>
    /// Alternative B: Parts
    /// The required parts needs to be referenced(Image, GameoObject, etc..)
    /// PROS: Only the required parts will be references (No need to serialize empty references)
    /// CONS: 
    /// </summary>
    [Header("Level Parts")]
    [SerializeField] private LevelTextsUIPart _levelText;
    [SerializeField] private GameObjectUIPart _levelHighlight;
    [SerializeField] private ImageUIPart _levelIcon;

    private LevelUIController _levelController;

    private void Start()
    {
        /// NOTE: Building Parts this way help us identify unused/non_referenced components faster. This accelerate bugs detection
        _levelController = new LevelUIController(new LevelUIController.Parts
        {
            LevelText = _levelText,
            Highlight = _levelHighlight,
            Icon = null
        }, LevelManager.Instance.LevelRaw, LevelManager.Instance.MaxLevelRaw);
    } 
}
