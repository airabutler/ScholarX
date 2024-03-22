; ModuleID = 'obj/Debug/android/marshal_methods.armeabi-v7a.ll'
source_filename = "obj/Debug/android/marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [156 x i32] [
	i32 57263871, ; 0: Xamarin.Forms.Core.dll => 0x369c6ff => 63
	i32 57967248, ; 1: Xamarin.Android.Support.VersionedParcelable.dll => 0x3748290 => 60
	i32 160529393, ; 2: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 25
	i32 166922606, ; 3: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 36
	i32 201930040, ; 4: Xamarin.Android.Arch.Core.Runtime => 0xc093538 => 26
	i32 219130465, ; 5: Xamarin.Android.Support.v4 => 0xd0faa61 => 55
	i32 232815796, ; 6: System.Web.Services => 0xde07cb4 => 76
	i32 293914992, ; 7: Xamarin.Android.Support.Transition => 0x1184c970 => 54
	i32 321597661, ; 8: System.Numerics => 0x132b30dd => 19
	i32 329550603, ; 9: Plugin.LocalNotifications => 0x13a48b0b => 9
	i32 347068432, ; 10: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 13
	i32 385762202, ; 11: System.Memory.dll => 0x16fe439a => 18
	i32 388313361, ; 12: Xamarin.Android.Support.Animated.Vector.Drawable => 0x17253111 => 32
	i32 389971796, ; 13: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 38
	i32 392495363, ; 14: ABC971 => 0x17650103 => 3
	i32 442521989, ; 15: Xamarin.Essentials => 0x1a605985 => 62
	i32 465846621, ; 16: mscorlib => 0x1bc4415d => 7
	i32 469710990, ; 17: System.dll => 0x1bff388e => 17
	i32 514659665, ; 18: Xamarin.Android.Support.Compat => 0x1ead1551 => 36
	i32 524864063, ; 19: Xamarin.Android.Support.Print => 0x1f48ca3f => 51
	i32 526420162, ; 20: System.Transactions.dll => 0x1f6088c2 => 70
	i32 539750087, ; 21: Xamarin.Android.Support.Design => 0x202beec7 => 43
	i32 569105624, ; 22: ABC971.Android => 0x21ebdcd8 => 0
	i32 571524804, ; 23: Xamarin.Android.Support.v7.RecyclerView => 0x2210c6c4 => 58
	i32 605376203, ; 24: System.IO.Compression.FileSystem => 0x24154ecb => 74
	i32 690569205, ; 25: System.Xml.Linq.dll => 0x29293ff5 => 24
	i32 692692150, ; 26: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 33
	i32 748832960, ; 27: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 11
	i32 775507847, ; 28: System.IO.Compression => 0x2e394f87 => 73
	i32 801787702, ; 29: Xamarin.Android.Support.Interpolator => 0x2fca4f36 => 47
	i32 809851609, ; 30: System.Drawing.Common.dll => 0x30455ad9 => 72
	i32 882883187, ; 31: Xamarin.Android.Support.v4.dll => 0x349fba73 => 55
	i32 916714535, ; 32: Xamarin.Android.Support.Print.dll => 0x36a3f427 => 51
	i32 958213972, ; 33: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 50
	i32 974778368, ; 34: FormsViewGroup.dll => 0x3a19f000 => 4
	i32 987342438, ; 35: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0x3ad9a666 => 29
	i32 1042160112, ; 36: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 65
	i32 1098167829, ; 37: Xamarin.Android.Arch.Lifecycle.ViewModel => 0x4174b615 => 31
	i32 1098259244, ; 38: System => 0x41761b2c => 17
	i32 1292207520, ; 39: SQLitePCLRaw.core.dll => 0x4d0585a0 => 12
	i32 1292763917, ; 40: Xamarin.Android.Support.CursorAdapter.dll => 0x4d0e030d => 40
	i32 1297413738, ; 41: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0x4d54f66a => 28
	i32 1359785034, ; 42: Xamarin.Android.Support.Design.dll => 0x510cac4a => 43
	i32 1365406463, ; 43: System.ServiceModel.Internals.dll => 0x516272ff => 67
	i32 1398662675, ; 44: ABC971.dll => 0x535de613 => 3
	i32 1411638395, ; 45: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 21
	i32 1445445088, ; 46: Xamarin.Android.Support.Fragment => 0x5627bde0 => 46
	i32 1460219004, ; 47: Xamarin.Forms.Xaml => 0x57092c7c => 66
	i32 1462112819, ; 48: System.IO.Compression.dll => 0x57261233 => 73
	i32 1574652163, ; 49: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 39
	i32 1587447679, ; 50: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 25
	i32 1592978981, ; 51: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1639515021, ; 52: System.Net.Http.dll => 0x61b9038d => 1
	i32 1657153582, ; 53: System.Runtime => 0x62c6282e => 22
	i32 1662014763, ; 54: Xamarin.Android.Support.Vector.Drawable => 0x6310552b => 59
	i32 1711441057, ; 55: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 13
	i32 1776026572, ; 56: System.Core.dll => 0x69dc03cc => 16
	i32 1818375724, ; 57: Plugin.LocalNotifications.Abstractions => 0x6c62362c => 8
	i32 1866717392, ; 58: Xamarin.Android.Support.Interpolator.dll => 0x6f43d8d0 => 47
	i32 1867746548, ; 59: Xamarin.Essentials.dll => 0x6f538cf4 => 62
	i32 1877418711, ; 60: Xamarin.Android.Support.v7.RecyclerView.dll => 0x6fe722d7 => 58
	i32 1878053835, ; 61: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 66
	i32 1916660109, ; 62: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x723de98d => 31
	i32 2011961780, ; 63: System.Buffers.dll => 0x77ec19b4 => 15
	i32 2037417872, ; 64: Xamarin.Android.Support.ViewPager => 0x79708790 => 61
	i32 2044222327, ; 65: Xamarin.Android.Support.Loader => 0x79d85b77 => 48
	i32 2079903147, ; 66: System.Runtime.dll => 0x7bf8cdab => 22
	i32 2090596640, ; 67: System.Numerics.Vectors => 0x7c9bf920 => 20
	i32 2103459038, ; 68: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 14
	i32 2126786730, ; 69: Xamarin.Forms.Platform.Android => 0x7ec430aa => 64
	i32 2139458754, ; 70: Xamarin.Android.Support.DrawerLayout => 0x7f858cc2 => 45
	i32 2166116741, ; 71: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 39
	i32 2196165013, ; 72: Xamarin.Android.Support.VersionedParcelable => 0x82e6d195 => 60
	i32 2201231467, ; 73: System.Net.Http => 0x8334206b => 1
	i32 2330457430, ; 74: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 38
	i32 2330986192, ; 75: Xamarin.Android.Support.SlidingPaneLayout.dll => 0x8af006d0 => 52
	i32 2373288475, ; 76: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 46
	i32 2440966767, ; 77: Xamarin.Android.Support.Loader.dll => 0x917e326f => 48
	i32 2465273461, ; 78: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 11
	i32 2471841756, ; 79: netstandard.dll => 0x93554fdc => 68
	i32 2475788418, ; 80: Java.Interop.dll => 0x93918882 => 5
	i32 2487632829, ; 81: Xamarin.Android.Support.DocumentFile => 0x944643bd => 44
	i32 2501346920, ; 82: System.Data.DataSetExtensions => 0x95178668 => 71
	i32 2555655126, ; 83: Plugin.LocalNotifications.Abstractions.dll => 0x985433d6 => 8
	i32 2698266930, ; 84: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa0d44932 => 29
	i32 2751899777, ; 85: Xamarin.Android.Support.Collections => 0xa406a881 => 35
	i32 2766581644, ; 86: Xamarin.Forms.Core => 0xa4e6af8c => 63
	i32 2782647110, ; 87: Xamarin.Android.Support.CustomTabs.dll => 0xa5dbd346 => 41
	i32 2788639665, ; 88: Xamarin.Android.Support.LocalBroadcastManager => 0xa63743b1 => 49
	i32 2788775637, ; 89: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0xa63956d5 => 53
	i32 2819470561, ; 90: System.Xml.dll => 0xa80db4e1 => 23
	i32 2876493027, ; 91: Xamarin.Android.Support.SwipeRefreshLayout => 0xab73cce3 => 53
	i32 2893257763, ; 92: Xamarin.Android.Arch.Core.Runtime.dll => 0xac739c23 => 26
	i32 2903344695, ; 93: System.ComponentModel.Composition => 0xad0d8637 => 75
	i32 2905242038, ; 94: mscorlib.dll => 0xad2a79b6 => 7
	i32 2919462931, ; 95: System.Numerics.Vectors.dll => 0xae037813 => 20
	i32 2921692953, ; 96: Xamarin.Android.Support.CustomView.dll => 0xae257f19 => 42
	i32 2922925221, ; 97: Xamarin.Android.Support.Vector.Drawable.dll => 0xae384ca5 => 59
	i32 3044182254, ; 98: FormsViewGroup => 0xb57288ee => 4
	i32 3056250942, ; 99: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0xb62ab03e => 34
	i32 3068715062, ; 100: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 27
	i32 3092211740, ; 101: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 50
	i32 3111772706, ; 102: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3178517120, ; 103: Plugin.LocalNotifications.dll => 0xbd745280 => 9
	i32 3191408315, ; 104: Xamarin.Android.Support.CustomTabs => 0xbe3906bb => 41
	i32 3204380047, ; 105: System.Data.dll => 0xbefef58f => 69
	i32 3204912593, ; 106: Xamarin.Android.Support.AsyncLayoutInflater => 0xbf0715d1 => 34
	i32 3233339011, ; 107: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xc0b8d683 => 28
	i32 3247949154, ; 108: Mono.Security => 0xc197c562 => 77
	i32 3286872994, ; 109: SQLite-net.dll => 0xc3e9b3a2 => 10
	i32 3296380511, ; 110: Xamarin.Android.Support.Collections.dll => 0xc47ac65f => 35
	i32 3317144872, ; 111: System.Data => 0xc5b79d28 => 69
	i32 3321585405, ; 112: Xamarin.Android.Support.DocumentFile.dll => 0xc5fb5efd => 44
	i32 3352662376, ; 113: Xamarin.Android.Support.CoordinaterLayout => 0xc7d59168 => 37
	i32 3357663996, ; 114: Xamarin.Android.Support.CursorAdapter => 0xc821e2fc => 40
	i32 3360279109, ; 115: SQLitePCLRaw.core => 0xc849ca45 => 12
	i32 3366347497, ; 116: Java.Interop => 0xc8a662e9 => 5
	i32 3395150330, ; 117: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 21
	i32 3404865022, ; 118: System.ServiceModel.Internals => 0xcaf21dfe => 67
	i32 3429136800, ; 119: System.Xml => 0xcc6479a0 => 23
	i32 3430777524, ; 120: netstandard => 0xcc7d82b4 => 68
	i32 3439690031, ; 121: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 33
	i32 3476120550, ; 122: Mono.Android => 0xcf3163e6 => 6
	i32 3486566296, ; 123: System.Transactions => 0xcfd0c798 => 70
	i32 3498942916, ; 124: Xamarin.Android.Support.v7.CardView.dll => 0xd08da1c4 => 57
	i32 3509114376, ; 125: System.Xml.Linq => 0xd128d608 => 24
	i32 3536029504, ; 126: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 64
	i32 3547625832, ; 127: Xamarin.Android.Support.SlidingPaneLayout => 0xd3747968 => 52
	i32 3567349600, ; 128: System.ComponentModel.Composition.dll => 0xd4a16f60 => 75
	i32 3632359727, ; 129: Xamarin.Forms.Platform => 0xd881692f => 65
	i32 3664423555, ; 130: Xamarin.Android.Support.ViewPager.dll => 0xda6aaa83 => 61
	i32 3672681054, ; 131: Mono.Android.dll => 0xdae8aa5e => 6
	i32 3676310014, ; 132: System.Web.Services.dll => 0xdb2009fe => 76
	i32 3678221644, ; 133: Xamarin.Android.Support.v7.AppCompat => 0xdb3d354c => 56
	i32 3681174138, ; 134: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 27
	i32 3689375977, ; 135: System.Drawing.Common => 0xdbe768e9 => 72
	i32 3714038699, ; 136: Xamarin.Android.Support.LocalBroadcastManager.dll => 0xdd5fbbab => 49
	i32 3718463572, ; 137: Xamarin.Android.Support.Animated.Vector.Drawable.dll => 0xdda34054 => 32
	i32 3754567612, ; 138: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 14
	i32 3776062606, ; 139: Xamarin.Android.Support.DrawerLayout.dll => 0xe112248e => 45
	i32 3829621856, ; 140: System.Numerics.dll => 0xe4436460 => 19
	i32 3832731800, ; 141: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe472d898 => 37
	i32 3862817207, ; 142: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 30
	i32 3874897629, ; 143: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 30
	i32 3876362041, ; 144: SQLite-net => 0xe70c9739 => 10
	i32 3883175360, ; 145: Xamarin.Android.Support.v7.AppCompat.dll => 0xe7748dc0 => 56
	i32 3920810846, ; 146: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 74
	i32 3945713374, ; 147: System.Data.DataSetExtensions.dll => 0xeb2ecede => 71
	i32 4025784931, ; 148: System.Memory => 0xeff49a63 => 18
	i32 4063435586, ; 149: Xamarin.Android.Support.CustomView => 0xf2331b42 => 42
	i32 4105002889, ; 150: Mono.Security.dll => 0xf4ad5f89 => 77
	i32 4151237749, ; 151: System.Core => 0xf76edc75 => 16
	i32 4216993138, ; 152: Xamarin.Android.Support.Transition.dll => 0xfb5a3572 => 54
	i32 4219003402, ; 153: Xamarin.Android.Support.v7.CardView => 0xfb78e20a => 57
	i32 4260525087, ; 154: System.Buffers => 0xfdf2741f => 15
	i32 4276326659 ; 155: ABC971.Android.dll => 0xfee39103 => 0
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [156 x i32] [
	i32 63, i32 60, i32 25, i32 36, i32 26, i32 55, i32 76, i32 54, ; 0..7
	i32 19, i32 9, i32 13, i32 18, i32 32, i32 38, i32 3, i32 62, ; 8..15
	i32 7, i32 17, i32 36, i32 51, i32 70, i32 43, i32 0, i32 58, ; 16..23
	i32 74, i32 24, i32 33, i32 11, i32 73, i32 47, i32 72, i32 55, ; 24..31
	i32 51, i32 50, i32 4, i32 29, i32 65, i32 31, i32 17, i32 12, ; 32..39
	i32 40, i32 28, i32 43, i32 67, i32 3, i32 21, i32 46, i32 66, ; 40..47
	i32 73, i32 39, i32 25, i32 2, i32 1, i32 22, i32 59, i32 13, ; 48..55
	i32 16, i32 8, i32 47, i32 62, i32 58, i32 66, i32 31, i32 15, ; 56..63
	i32 61, i32 48, i32 22, i32 20, i32 14, i32 64, i32 45, i32 39, ; 64..71
	i32 60, i32 1, i32 38, i32 52, i32 46, i32 48, i32 11, i32 68, ; 72..79
	i32 5, i32 44, i32 71, i32 8, i32 29, i32 35, i32 63, i32 41, ; 80..87
	i32 49, i32 53, i32 23, i32 53, i32 26, i32 75, i32 7, i32 20, ; 88..95
	i32 42, i32 59, i32 4, i32 34, i32 27, i32 50, i32 2, i32 9, ; 96..103
	i32 41, i32 69, i32 34, i32 28, i32 77, i32 10, i32 35, i32 69, ; 104..111
	i32 44, i32 37, i32 40, i32 12, i32 5, i32 21, i32 67, i32 23, ; 112..119
	i32 68, i32 33, i32 6, i32 70, i32 57, i32 24, i32 64, i32 52, ; 120..127
	i32 75, i32 65, i32 61, i32 6, i32 76, i32 56, i32 27, i32 72, ; 128..135
	i32 49, i32 32, i32 14, i32 45, i32 19, i32 37, i32 30, i32 30, ; 136..143
	i32 10, i32 56, i32 74, i32 71, i32 18, i32 42, i32 77, i32 16, ; 144..151
	i32 54, i32 57, i32 15, i32 0 ; 152..155
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ a8a26c7b003e2524cc98acb2c2ffc2ddea0f6692"}
!llvm.linker.options = !{}
