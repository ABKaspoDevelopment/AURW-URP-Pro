﻿// Crest Ocean System

// Copyright 2021 Wave Harmonic Ltd

namespace Crest
{
    using UnityEngine;

#if UNITY_EDITOR
    using Crest.EditorHelpers;
    using UnityEditor;
#endif

    public class EmbeddedAttribute : DecoratedPropertyAttribute
    {
#if UNITY_EDITOR
        internal EmbeddedAssetEditor editor;
#endif

        public EmbeddedAttribute()
        {
#if UNITY_EDITOR
            editor = new EmbeddedAssetEditor();
#endif
        }

#if UNITY_EDITOR
        internal override void OnGUI(Rect position, SerializedProperty property, GUIContent label, DecoratedDrawer drawer)
        {
            EmbeddedAttribute embeddedAttribute = this;
            embeddedAttribute.editor.DrawEditorCombo(label, drawer, property, "asset");
        }

        // Removes space above embedded editor so the embedded editor replaces this drawer.
        internal override float? GetPropertyHeight(SerializedProperty property, GUIContent label) => 0f;
#endif
    }
}
