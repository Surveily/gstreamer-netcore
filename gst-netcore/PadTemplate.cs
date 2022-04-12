namespace Gst
{
#if NETCOREAPP3_0 || NETCOREAPP3_1 || NET6_0
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public partial class PadTemplate : Gst.Object
    {
        public PadTemplate(IntPtr raw) : base(raw) { }

        [DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr gst_pad_template_new(IntPtr name_template, int direction, int presence, IntPtr caps);

        public PadTemplate(string name_template, Gst.PadDirection direction, Gst.PadPresence presence, Gst.Caps caps) : base(IntPtr.Zero)
        {
            if (GetType() != typeof(PadTemplate))
            {
                var vals = new List<GLib.Value>();
                var names = new List<string>();
                names.Add("name_template");
                vals.Add(new GLib.Value(name_template));
                names.Add("direction");
                vals.Add(new GLib.Value(direction));
                names.Add("presence");
                vals.Add(new GLib.Value(presence));
                if (caps != null)
                {
                    names.Add("caps");
                    vals.Add(new GLib.Value(caps));
                }
                CreateNativeObject(names.ToArray(), vals.ToArray());
                return;
            }
            IntPtr native_name_template = GLib.Marshaller.StringToPtrGStrdup(name_template);
            Raw = gst_pad_template_new(native_name_template, (int)direction, (int)presence, caps == null ? IntPtr.Zero : caps.Handle);
            GLib.Marshaller.Free(native_name_template);
        }

        [DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr gst_pad_template_new_from_static_pad_template_with_gtype(IntPtr pad_template, IntPtr pad_type);

        public PadTemplate(Gst.StaticPadTemplate pad_template, GLib.GType pad_type) : base(IntPtr.Zero)
        {
            if (GetType() != typeof(PadTemplate))
            {
                var vals = new List<GLib.Value>();
                var names = new List<string>();
                CreateNativeObject(names.ToArray(), vals.ToArray());
                return;
            }
            IntPtr native_pad_template = GLib.Marshaller.StructureToPtrAlloc(pad_template);
            Raw = gst_pad_template_new_from_static_pad_template_with_gtype(native_pad_template, pad_type.Val);
            Marshal.FreeHGlobal(native_pad_template);
        }

        [DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr gst_pad_template_new_with_gtype(IntPtr name_template, int direction, int presence, IntPtr caps, IntPtr pad_type);

        public PadTemplate(string name_template, Gst.PadDirection direction, Gst.PadPresence presence, Gst.Caps caps, GLib.GType pad_type) : base(IntPtr.Zero)
        {
            if (GetType() != typeof(PadTemplate))
            {
                var vals = new List<GLib.Value>();
                var names = new List<string>();
                names.Add("name_template");
                vals.Add(new GLib.Value(name_template));
                names.Add("direction");
                vals.Add(new GLib.Value(direction));
                names.Add("presence");
                vals.Add(new GLib.Value(presence));
                if (caps != null)
                {
                    names.Add("caps");
                    vals.Add(new GLib.Value(caps));
                }
                CreateNativeObject(names.ToArray(), vals.ToArray());
                return;
            }
            IntPtr native_name_template = GLib.Marshaller.StringToPtrGStrdup(name_template);
            Raw = gst_pad_template_new_with_gtype(native_name_template, (int)direction, (int)presence, caps == null ? IntPtr.Zero : caps.Handle, pad_type.Val);
            GLib.Marshaller.Free(native_name_template);
        }

        [DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr gst_pad_template_get_caps(IntPtr raw);

        [GLib.Property("caps")]
        public Gst.Caps Caps
        {
            get
            {
                IntPtr raw_ret = gst_pad_template_get_caps(Handle);
                Gst.Caps ret = raw_ret == IntPtr.Zero ? null : (Gst.Caps)GLib.Opaque.GetOpaque(raw_ret, typeof(Gst.Caps), true);
                return ret;
            }
        }

        [GLib.Property("direction")]
        public Gst.PadDirection Direction
        {
            get
            {
                GLib.Value val = GetProperty("direction");
                Gst.PadDirection ret = (Gst.PadDirection)(Enum)val;
                val.Dispose();
                return ret;
            }
        }

        [GLib.Property("gtype")]
        public GLib.GType Gtype
        {
            get
            {
                GLib.Value val = GetProperty("gtype");
                GLib.GType ret = (GLib.GType)val.Val; // .NET Core fix
                val.Dispose();
                return ret;
            }
        }

        [GLib.Property("name-template")]
        public string NameTemplate
        {
            get
            {
                GLib.Value val = GetProperty("name-template");
                string ret = (string)val;
                val.Dispose();
                return ret;
            }
        }

        [GLib.Property("presence")]
        public Gst.PadPresence Presence
        {
            get
            {
                GLib.Value val = GetProperty("presence");
                Gst.PadPresence ret = (Gst.PadPresence)(Enum)val;
                val.Dispose();
                return ret;
            }
        }

        public string NameTemplateField
        {
            get
            {
                unsafe
                {
                    IntPtr* raw_ptr = (IntPtr*)(((byte*)Handle) + abi_info.GetFieldOffset("name_template"));
                    return GLib.Marshaller.Utf8PtrToString((*raw_ptr));
                }
            }
        }

        public Gst.PadDirection DirectionField
        {
            get
            {
                unsafe
                {
                    int* raw_ptr = (int*)(((byte*)Handle) + abi_info.GetFieldOffset("direction"));
                    return (Gst.PadDirection)(*raw_ptr);
                }
            }
        }

        public Gst.PadPresence PresenceField
        {
            get
            {
                unsafe
                {
                    int* raw_ptr = (int*)(((byte*)Handle) + abi_info.GetFieldOffset("presence"));
                    return (Gst.PadPresence)(*raw_ptr);
                }
            }
        }

        public Gst.Caps CapsField
        {
            get
            {
                unsafe
                {
                    IntPtr* raw_ptr = (IntPtr*)(((byte*)Handle) + abi_info.GetFieldOffset("caps"));
                    return (*raw_ptr) == IntPtr.Zero ? null : (Gst.Caps)GLib.Opaque.GetOpaque((*raw_ptr), typeof(Gst.Caps), false);
                }
            }
        }

        [GLib.Signal("pad-created")]
        public event Gst.PadCreatedEventHandler PadCreatedEvent
        {
            add
            {
                this.AddSignalHandler("pad-created", value, typeof(Gst.PadCreatedEventArgs));
            }
            remove
            {
                this.RemoveSignalHandler("pad-created", value);
            }
        }

        static PadCreatedEventNativeDelegate PadCreatedEvent_cb_delegate;
        static PadCreatedEventNativeDelegate PadCreatedEventVMCallback
        {
            get
            {
                if (PadCreatedEvent_cb_delegate == null)
                    PadCreatedEvent_cb_delegate = new PadCreatedEventNativeDelegate(PadCreatedEvent_cb);
                return PadCreatedEvent_cb_delegate;
            }
        }

        static void OverridePadCreatedEvent(GLib.GType gtype)
        {
            OverridePadCreatedEvent(gtype, PadCreatedEventVMCallback);
        }

        static void OverridePadCreatedEvent(GLib.GType gtype, PadCreatedEventNativeDelegate callback)
        {
            unsafe
            {
                IntPtr* raw_ptr = (IntPtr*)(((long)gtype.GetClassPtr()) + (long)class_abi.GetFieldOffset("pad_created"));
                *raw_ptr = Marshal.GetFunctionPointerForDelegate((Delegate)callback);
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void PadCreatedEventNativeDelegate(IntPtr inst, IntPtr pad);

        static void PadCreatedEvent_cb(IntPtr inst, IntPtr pad)
        {
            try
            {
                PadTemplate __obj = GLib.Object.GetObject(inst, false) as PadTemplate;
                __obj.OnPadCreatedEvent(GLib.Object.GetObject(pad) as Gst.Pad);
            }
            catch (Exception e)
            {
                GLib.ExceptionManager.RaiseUnhandledException(e, false);
            }
        }

        [GLib.DefaultSignalHandler(Type = typeof(Gst.PadTemplate), ConnectionMethod = "OverridePadCreatedEvent")]
        protected virtual void OnPadCreatedEvent(Gst.Pad pad)
        {
            InternalPadCreatedEvent(pad);
        }

        private void InternalPadCreatedEvent(Gst.Pad pad)
        {
            PadCreatedEventNativeDelegate unmanaged = null;
            unsafe
            {
                IntPtr* raw_ptr = (IntPtr*)(((long)this.LookupGType().GetThresholdType().GetClassPtr()) + (long)class_abi.GetFieldOffset("pad_created"));
                unmanaged = (PadCreatedEventNativeDelegate)Marshal.GetDelegateForFunctionPointer(*raw_ptr, typeof(PadCreatedEventNativeDelegate));
            }
            if (unmanaged == null) return;

            unmanaged(this.Handle, pad == null ? IntPtr.Zero : pad.Handle);
        }


        // Internal representation of the wrapped structure ABI.
        static GLib.AbiStruct _class_abi = null;
        static public new GLib.AbiStruct class_abi
        {
            get
            {
                if (_class_abi == null)
                    _class_abi = new GLib.AbiStruct(new List<GLib.AbiField>{
                        new GLib.AbiField("pad_created"
                            , Gst.Object.class_abi.Fields
                            , (uint) Marshal.SizeOf(typeof(IntPtr)) // pad_created
							, null
                            , "_gst_reserved"
                            , (uint) Marshal.SizeOf(typeof(IntPtr))
                            , 0
                            ),
                        new GLib.AbiField("_gst_reserved"
                            , -1
                            , (uint) Marshal.SizeOf(typeof(IntPtr)) * 4 // _gst_reserved
							, "pad_created"
                            , null
                            , (uint) Marshal.SizeOf(typeof(IntPtr))
                            , 0
                            ),
                    });

                return _class_abi;
            }
        }


        // End of the ABI representation.

        [DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr gst_pad_template_get_type();

        public static new GLib.GType GType
        {
            get
            {
                IntPtr raw_ret = gst_pad_template_get_type();
                GLib.GType ret = new GLib.GType(raw_ret);
                return ret;
            }
        }

        [DllImport("gstreamer-1.0-0.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern void gst_pad_template_pad_created(IntPtr raw, IntPtr pad);

        public void PadCreated(Gst.Pad pad)
        {
            gst_pad_template_pad_created(Handle, pad == null ? IntPtr.Zero : pad.Handle);
        }


        // Internal representation of the wrapped structure ABI.
        static GLib.AbiStruct _abi_info = null;
        static public new GLib.AbiStruct abi_info
        {
            get
            {
                if (_abi_info == null)
                    _abi_info = new GLib.AbiStruct(new List<GLib.AbiField>{
                        new GLib.AbiField("name_template"
                            , Gst.Object.abi_info.Fields
                            , (uint) Marshal.SizeOf(typeof(IntPtr)) // name_template
							, null
                            , "direction"
                            , (uint) Marshal.SizeOf(typeof(IntPtr))
                            , 0
                            ),
                        new GLib.AbiField("direction"
                            , -1
                            , (uint) Marshal.SizeOf(System.Enum.GetUnderlyingType(typeof(Gst.PadDirection))) // direction
							, "name_template"
                            , "presence"
                            , (long) Marshal.OffsetOf(typeof(GstPadTemplate_directionAlign), "direction")
                            , 0
                            ),
                        new GLib.AbiField("presence"
                            , -1
                            , (uint) Marshal.SizeOf(System.Enum.GetUnderlyingType(typeof(Gst.PadPresence))) // presence
							, "direction"
                            , "caps"
                            , (long) Marshal.OffsetOf(typeof(GstPadTemplate_presenceAlign), "presence")
                            , 0
                            ),
                        new GLib.AbiField("caps"
                            , -1
                            , (uint) Marshal.SizeOf(typeof(IntPtr)) // caps
							, "presence"
                            , "ABI"
                            , (uint) Marshal.SizeOf(typeof(IntPtr))
                            , 0
                            ),
						// union struct ABI
							new GLib.AbiField("ABI._gst_reserved"
                                , -1
                                , (uint) Marshal.SizeOf(typeof(IntPtr)) * 4 // ABI._gst_reserved
								, "caps"
                                , null
                                , (uint) Marshal.SizeOf(typeof(IntPtr))
                                , 0
                                ),
						// End ABI

						// union struct ABI.abi
							new GLib.AbiField("ABI.abi.gtype"
                                , -1
                                , (uint) Marshal.SizeOf(typeof(GLib.GType)) // ABI.abi.gtype
								, "caps"
                                , null
                                , (long) Marshal.OffsetOf(typeof(GstPadTemplate_ABI_abi_gtypeAlign), "ABI_abi_gtype")
                                , 0
                                ),
						// End ABI.abi

						new GLib.AbiField("ABI"
                            , -1
                            , new List<List<string>>() {  // union ABI
						new List<string>() {"ABI._gst_reserved"},
                        new List<string>() {"ABI.abi.gtype"}
                      }
                            , "caps"
                            , null
                            , 0
                            ),
                    });

                return _abi_info;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GstPadTemplate_directionAlign
        {
            sbyte f1;
            private Gst.PadDirection direction;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GstPadTemplate_presenceAlign
        {
            sbyte f1;
            private Gst.PadPresence presence;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GstPadTemplate_ABI_abi_gtypeAlign
        {
            sbyte f1;
            private GLib.GType ABI_abi_gtype;
        }
    }
#endif
}
