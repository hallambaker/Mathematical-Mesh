﻿using Goedel.Utilities;

using System;
using System.Collections;

namespace Goedel.Guigen;


public interface IPresentation {
    }




public interface IBindable {
    
    ///<summary>Returns the binding for the data type</summary> 
    public GuiBinding OldBind { get; }



    }

public interface IParameter : IBindable {




    public bool Validate();

    }


public interface IResult : IBindable {

    }

public record GuiBinding {

    public GuiBoundProperty[] BoundProperties { get; }



    public GuiBinding(GuiBoundProperty[] boundProperties) {
        BoundProperties = boundProperties;
        }

    }

public record GuiBoundProperty  {
    ///<summary>Error to be filled if Validate is called and finds an error</summary> 
    public string? Error { get; set; } = null;

    }


public record GuiBoundPropertyString (
                Func<IBindable, string> Get,
                Action<IBindable, string> Set,
                string? Label = null) : GuiBoundProperty {
    }

public record GuiBoundPropertyChooser(
                Func<IBindable, ISelectCollection> Get,
                Action<IBindable, ISelectCollection> Set,
                string? Label = null) : GuiBoundProperty {
    }

public record GuiBoundPropertyColor(
                Func<IBindable, IFieldColor> Get,
                Action<IBindable, IFieldColor> Set,
                string? Label = null) : GuiBoundProperty {
    }


public record GuiBoundPropertySize(
                Func<IBindable, IFieldSize> Get,
                Action<IBindable, IFieldSize> Set,
                string? Label = null) : GuiBoundProperty {
    }


public record GuiBoundPropertyDecimal(
                Func<IBindable, double> Get,
                Action<IBindable, double> Set,
                string? Label = null) : GuiBoundProperty {
    }


public record GuiBoundPropertyIcon(
                Func<IBindable, IFieldIcon> Get,
                Action<IBindable, IFieldIcon> Set,
                string? Label = null) : GuiBoundProperty {
    }



///<summary></summary> 
public record GuiImage (
            string Icon
            ){
    }


public record GuiItem(
            string Id) {
    }

public record GuiDialog : GuiItem , IGuiEntry {
    public IPresentation? Presentation { get; set; } = null;

    public string Id { get; set; }
    public List<IGuiEntry> Entries { get; set; } = null!;

    public GuiDialog(
           string id,
            List<IGuiEntry> entries = null!
           ) : base(id){
        Id = id;
        Entries = entries;

        }


    }




public record GuiButton(
            string Id,
            IButtonTarget Target
            ) : GuiItem(Id), IGuiEntry {


    }


public record GuiPrompt(
            string Id,
            string Prompt
            ) : GuiItem(Id), IGuiEntry {



    }


public record GuiSection (
            string Id,
            string Prompt,
            string Icon,
            bool Primary
            ) : GuiPrompt(Id, Prompt), IButtonTarget {
    public IPresentation? Presentation { get; set; } = null;


    public IBindable? Data {
            get => data ?? BindData().CacheValue(out data);
            set => data = value; } 
    IBindable? data = null;

    public Func<IBindable> BindData { get; set; } = null!;

    public List<IGuiEntry> Entries { get; set; } = null!;


    }


public delegate IResult ActionCallback(object IBindable);
public delegate IBindable FactoryCallback();
public record GuiAction(
            string Id,
            string Prompt,
            string Icon,
            FactoryCallback Factory
            ) : GuiPrompt(Id, Prompt), IButtonTarget {
    public IPresentation? Presentation { get; set; } = null;

    public List<IGuiEntry> Entries { get; set; } = null!;

    public ActionCallback Callback { get; set; } = null!;
    }


public record GuiField(
            string Id,
            string Prompt,
            int Index
            ) : GuiPrompt(Id, Prompt), IGuiEntry {
    }

public record GuiChooser(
            string Id,
            string Prompt,
            string Icon,
            int Index = -1,
            //GuiBinding Binding,
            List<IGuiEntry> Entries = null!
            ) : GuiField(Id, Prompt, Index), IGuiEntry {


    }






public record GuiContext(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField (Id, Prompt, Index) { 
    }

public record GuiText(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }

public record GuiColor(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }
public record GuiSize(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }
public record GuiDecimal(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }
public record GuiIcon(
            string Id,
            string Prompt,
            int Index = -1
            ) : GuiField(Id, Prompt, Index) {
    }


public record GuiView(
            GuiBinding Binding
            ) : IGuiEntry {
    }



public interface IGuiEntry {
    }



//public interface ISectionEntry {
//    }

//public interface IActionEntry {
//    }

//public interface IDialogEntry {
//    }

//public interface IChooserEntry {
//    }

public interface IButtonTarget {
    }



public interface IFieldColor {
    }

public interface IFieldSize {
    }
public interface IFieldIcon {
    }



public interface ISelectCollection : IEnumerable{
    }