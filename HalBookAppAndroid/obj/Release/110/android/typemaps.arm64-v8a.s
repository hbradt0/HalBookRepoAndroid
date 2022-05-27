	.arch	armv8-a
	.file	"typemaps.arm64-v8a.s"

/* map_module_count: START */
	.section	.rodata.map_module_count,"a",@progbits
	.type	map_module_count, @object
	.p2align	2
	.global	map_module_count
map_module_count:
	.size	map_module_count, 4
	.word	17
/* map_module_count: END */

/* java_type_count: START */
	.section	.rodata.java_type_count,"a",@progbits
	.type	java_type_count, @object
	.p2align	2
	.global	java_type_count
java_type_count:
	.size	java_type_count, 4
	.word	382
/* java_type_count: END */

	.include	"typemaps.shared.inc"
	.include	"typemaps.arm64-v8a-managed.inc"

/* Managed to Java map: START */
	.section	.data.rel.map_modules,"aw",@progbits
	.type	map_modules, @object
	.p2align	3
	.global	map_modules
map_modules:
	/* module_uuid: 8c81d503-ba08-4e9e-955b-8e3f46e6259d */
	.byte	0x03, 0xd5, 0x81, 0x8c, 0x08, 0xba, 0x9e, 0x4e, 0x95, 0x5b, 0x8e, 0x3f, 0x46, 0xe6, 0x25, 0x9d
	/* entry_count */
	.word	3
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module0_managed_to_java
	/* duplicate_map */
	.xword	module0_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.DrawerLayout */
	.xword	.L.map_aname.0
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 1d973306-500c-45bc-a7d7-f86648aa18d4 */
	.byte	0x06, 0x33, 0x97, 0x1d, 0x0c, 0x50, 0xbc, 0x45, 0xa7, 0xd7, 0xf8, 0x66, 0x48, 0xaa, 0x18, 0xd4
	/* entry_count */
	.word	4
	/* duplicate_count */
	.word	3
	/* map */
	.xword	module1_managed_to_java
	/* duplicate_map */
	.xword	module1_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Lifecycle.Common */
	.xword	.L.map_aname.1
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 972fff0b-ebb0-452d-b81b-441068f3622b */
	.byte	0x0b, 0xff, 0x2f, 0x97, 0xb0, 0xeb, 0x2d, 0x45, 0xb8, 0x1b, 0x44, 0x10, 0x68, 0xf3, 0x62, 0x2b
	/* entry_count */
	.word	3
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module2_managed_to_java
	/* duplicate_map */
	.xword	module2_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.CoordinatorLayout */
	.xword	.L.map_aname.2
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: c76ff11b-7138-4abb-8c41-f6ce0b2c9f68 */
	.byte	0x1b, 0xf1, 0x6f, 0xc7, 0x38, 0x71, 0xbb, 0x4a, 0x8c, 0x41, 0xf6, 0xce, 0x0b, 0x2c, 0x9f, 0x68
	/* entry_count */
	.word	3
	/* duplicate_count */
	.word	2
	/* map */
	.xword	module3_managed_to_java
	/* duplicate_map */
	.xword	module3_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.SavedState */
	.xword	.L.map_aname.3
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 9b0a5e4b-5c35-44fe-80e8-38e6b6d18ba7 */
	.byte	0x4b, 0x5e, 0x0a, 0x9b, 0x35, 0x5c, 0xfe, 0x44, 0x80, 0xe8, 0x38, 0xe6, 0xb6, 0xd1, 0x8b, 0xa7
	/* entry_count */
	.word	31
	/* duplicate_count */
	.word	17
	/* map */
	.xword	module4_managed_to_java
	/* duplicate_map */
	.xword	module4_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.AppCompat */
	.xword	.L.map_aname.4
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 15834755-8da6-478f-9b50-617be9d46e8f */
	.byte	0x55, 0x47, 0x83, 0x15, 0xa6, 0x8d, 0x8f, 0x47, 0x9b, 0x50, 0x61, 0x7b, 0xe9, 0xd4, 0x6e, 0x8f
	/* entry_count */
	.word	10
	/* duplicate_count */
	.word	4
	/* map */
	.xword	module5_managed_to_java
	/* duplicate_map */
	.xword	module5_managed_to_java_duplicates
	/* assembly_name: Xamarin.Google.Android.Material */
	.xword	.L.map_aname.5
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 6af61659-5025-49b3-9422-56a118315201 */
	.byte	0x59, 0x16, 0xf6, 0x6a, 0x25, 0x50, 0xb3, 0x49, 0x94, 0x22, 0x56, 0xa1, 0x18, 0x31, 0x52, 0x01
	/* entry_count */
	.word	10
	/* duplicate_count */
	.word	5
	/* map */
	.xword	module6_managed_to_java
	/* duplicate_map */
	.xword	module6_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Fragment */
	.xword	.L.map_aname.6
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: d2b01d5a-b81d-4f62-80e2-c362d81d9cd9 */
	.byte	0x5a, 0x1d, 0xb0, 0xd2, 0x1d, 0xb8, 0x62, 0x4f, 0x80, 0xe2, 0xc3, 0x62, 0xd8, 0x1d, 0x9c, 0xd9
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module7_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Essentials */
	.xword	.L.map_aname.7
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 588f2762-4810-469a-9e98-ca81d4ff00d6 */
	.byte	0x62, 0x27, 0x8f, 0x58, 0x10, 0x48, 0x9a, 0x46, 0x9e, 0x98, 0xca, 0x81, 0xd4, 0xff, 0x00, 0xd6
	/* entry_count */
	.word	269
	/* duplicate_count */
	.word	132
	/* map */
	.xword	module8_managed_to_java
	/* duplicate_map */
	.xword	module8_managed_to_java_duplicates
	/* assembly_name: Mono.Android */
	.xword	.L.map_aname.8
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 8edf7564-b4c4-478c-b379-f35d8d5389d2 */
	.byte	0x64, 0x75, 0xdf, 0x8e, 0xc4, 0xb4, 0x8c, 0x47, 0xb3, 0x79, 0xf3, 0x5d, 0x8d, 0x53, 0x89, 0xd2
	/* entry_count */
	.word	32
	/* duplicate_count */
	.word	18
	/* map */
	.xword	module9_managed_to_java
	/* duplicate_map */
	.xword	module9_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Core */
	.xword	.L.map_aname.9
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 7a930668-dd13-4251-8497-a6477a49af1d */
	.byte	0x68, 0x06, 0x93, 0x7a, 0x13, 0xdd, 0x51, 0x42, 0x84, 0x97, 0xa6, 0x47, 0x7a, 0x49, 0xaf, 0x1d
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module10_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: HalBookAppAndroid */
	.xword	.L.map_aname.10
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 39474576-1024-4319-8815-86282e2971d8 */
	.byte	0x76, 0x45, 0x47, 0x39, 0x24, 0x10, 0x19, 0x43, 0x88, 0x15, 0x86, 0x28, 0x2e, 0x29, 0x71, 0xd8
	/* entry_count */
	.word	5
	/* duplicate_count */
	.word	4
	/* map */
	.xword	module11_managed_to_java
	/* duplicate_map */
	.xword	module11_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Loader */
	.xword	.L.map_aname.11
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: b034fa80-29bd-4559-8354-26a743f74253 */
	.byte	0x80, 0xfa, 0x34, 0xb0, 0xbd, 0x29, 0x59, 0x45, 0x83, 0x54, 0x26, 0xa7, 0x43, 0xf7, 0x42, 0x53
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module12_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.AndroidX.Activity */
	.xword	.L.map_aname.12
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 9ac1089a-eef9-4b98-b18e-ecbbdf857cee */
	.byte	0x9a, 0x08, 0xc1, 0x9a, 0xf9, 0xee, 0x98, 0x4b, 0xb1, 0x8e, 0xec, 0xbb, 0xdf, 0x85, 0x7c, 0xee
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	2
	/* map */
	.xword	module13_managed_to_java
	/* duplicate_map */
	.xword	module13_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Lifecycle.LiveData.Core */
	.xword	.L.map_aname.13
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 5d71c2a3-54dd-4890-8b03-0874d6551eff */
	.byte	0xa3, 0xc2, 0x71, 0x5d, 0xdd, 0x54, 0x90, 0x48, 0x8b, 0x03, 0x08, 0x74, 0xd6, 0x55, 0x1e, 0xff
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module14_managed_to_java
	/* duplicate_map */
	.xword	module14_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.CustomView */
	.xword	.L.map_aname.14
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 22ab85d9-c40c-4739-b6fe-c7ac6cfd022e */
	.byte	0xd9, 0x85, 0xab, 0x22, 0x0c, 0xc4, 0x39, 0x47, 0xb6, 0xfe, 0xc7, 0xac, 0x6c, 0xfd, 0x02, 0x2e
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module15_managed_to_java
	/* duplicate_map */
	.xword	module15_managed_to_java_duplicates
	/* assembly_name: Xamarin.Google.Guava.ListenableFuture */
	.xword	.L.map_aname.15
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 965ee4e5-b5e4-4fc6-9599-a10985f821f3 */
	.byte	0xe5, 0xe4, 0x5e, 0x96, 0xe4, 0xb5, 0xc6, 0x4f, 0x95, 0x99, 0xa1, 0x09, 0x85, 0xf8, 0x21, 0xf3
	/* entry_count */
	.word	5
	/* duplicate_count */
	.word	3
	/* map */
	.xword	module16_managed_to_java
	/* duplicate_map */
	.xword	module16_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Lifecycle.ViewModel */
	.xword	.L.map_aname.16
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	.size	map_modules, 1224
/* Managed to Java map: END */

/* Java to managed map: START */
	.section	.rodata.map_java,"a",@progbits
	.type	map_java, @object
	.p2align	2
	.global	map_java
map_java:
	/* #0 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554752
	/* java_name */
	.ascii	"android/animation/Animator"
	.zero	66

	/* #1 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorListener"
	.zero	49

	/* #2 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorPauseListener"
	.zero	44

	/* #3 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554758
	/* java_name */
	.ascii	"android/animation/AnimatorListenerAdapter"
	.zero	51

	/* #4 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/animation/TimeInterpolator"
	.zero	58

	/* #5 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554763
	/* java_name */
	.ascii	"android/app/Activity"
	.zero	72

	/* #6 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554764
	/* java_name */
	.ascii	"android/app/AlertDialog"
	.zero	69

	/* #7 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554765
	/* java_name */
	.ascii	"android/app/AlertDialog$Builder"
	.zero	61

	/* #8 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554766
	/* java_name */
	.ascii	"android/app/Application"
	.zero	69

	/* #9 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/app/Application$ActivityLifecycleCallbacks"
	.zero	42

	/* #10 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554769
	/* java_name */
	.ascii	"android/app/DatePickerDialog"
	.zero	64

	/* #11 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/app/DatePickerDialog$OnDateSetListener"
	.zero	46

	/* #12 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554774
	/* java_name */
	.ascii	"android/app/Dialog"
	.zero	74

	/* #13 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554775
	/* java_name */
	.ascii	"android/app/PendingIntent"
	.zero	67

	/* #14 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/content/ComponentCallbacks"
	.zero	58

	/* #15 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/content/ComponentCallbacks2"
	.zero	57

	/* #16 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554780
	/* java_name */
	.ascii	"android/content/ComponentName"
	.zero	63

	/* #17 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554781
	/* java_name */
	.ascii	"android/content/Context"
	.zero	69

	/* #18 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554783
	/* java_name */
	.ascii	"android/content/ContextWrapper"
	.zero	62

	/* #19 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/content/DialogInterface"
	.zero	61

	/* #20 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/content/DialogInterface$OnClickListener"
	.zero	45

	/* #21 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554794
	/* java_name */
	.ascii	"android/content/Intent"
	.zero	70

	/* #22 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554795
	/* java_name */
	.ascii	"android/content/IntentSender"
	.zero	64

	/* #23 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/content/SharedPreferences"
	.zero	59

	/* #24 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/content/SharedPreferences$Editor"
	.zero	52

	/* #25 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/content/SharedPreferences$OnSharedPreferenceChangeListener"
	.zero	26

	/* #26 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554808
	/* java_name */
	.ascii	"android/content/pm/PackageInfo"
	.zero	62

	/* #27 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554809
	/* java_name */
	.ascii	"android/content/pm/PackageManager"
	.zero	59

	/* #28 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554804
	/* java_name */
	.ascii	"android/content/res/AssetManager"
	.zero	60

	/* #29 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554805
	/* java_name */
	.ascii	"android/content/res/ColorStateList"
	.zero	58

	/* #30 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554806
	/* java_name */
	.ascii	"android/content/res/Configuration"
	.zero	59

	/* #31 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554807
	/* java_name */
	.ascii	"android/content/res/Resources"
	.zero	63

	/* #32 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554750
	/* java_name */
	.ascii	"android/database/DataSetObserver"
	.zero	60

	/* #33 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554731
	/* java_name */
	.ascii	"android/graphics/Bitmap"
	.zero	69

	/* #34 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554732
	/* java_name */
	.ascii	"android/graphics/Bitmap$CompressFormat"
	.zero	54

	/* #35 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554733
	/* java_name */
	.ascii	"android/graphics/BitmapFactory"
	.zero	62

	/* #36 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554734
	/* java_name */
	.ascii	"android/graphics/BlendMode"
	.zero	66

	/* #37 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554735
	/* java_name */
	.ascii	"android/graphics/Canvas"
	.zero	69

	/* #38 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554736
	/* java_name */
	.ascii	"android/graphics/ColorFilter"
	.zero	64

	/* #39 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554737
	/* java_name */
	.ascii	"android/graphics/Matrix"
	.zero	69

	/* #40 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554738
	/* java_name */
	.ascii	"android/graphics/Paint"
	.zero	70

	/* #41 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554739
	/* java_name */
	.ascii	"android/graphics/Point"
	.zero	70

	/* #42 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554740
	/* java_name */
	.ascii	"android/graphics/PorterDuff"
	.zero	65

	/* #43 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554741
	/* java_name */
	.ascii	"android/graphics/PorterDuff$Mode"
	.zero	60

	/* #44 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554742
	/* java_name */
	.ascii	"android/graphics/Rect"
	.zero	71

	/* #45 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554743
	/* java_name */
	.ascii	"android/graphics/RectF"
	.zero	70

	/* #46 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554745
	/* java_name */
	.ascii	"android/graphics/drawable/BitmapDrawable"
	.zero	52

	/* #47 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554746
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable"
	.zero	58

	/* #48 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$Callback"
	.zero	49

	/* #49 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554729
	/* java_name */
	.ascii	"android/media/ExifInterface"
	.zero	65

	/* #50 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554727
	/* java_name */
	.ascii	"android/net/Uri"
	.zero	77

	/* #51 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554713
	/* java_name */
	.ascii	"android/os/BaseBundle"
	.zero	71

	/* #52 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554714
	/* java_name */
	.ascii	"android/os/Build"
	.zero	76

	/* #53 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554715
	/* java_name */
	.ascii	"android/os/Build$VERSION"
	.zero	68

	/* #54 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554716
	/* java_name */
	.ascii	"android/os/Bundle"
	.zero	75

	/* #55 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554717
	/* java_name */
	.ascii	"android/os/Environment"
	.zero	70

	/* #56 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554718
	/* java_name */
	.ascii	"android/os/Handler"
	.zero	74

	/* #57 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554723
	/* java_name */
	.ascii	"android/os/Looper"
	.zero	75

	/* #58 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554724
	/* java_name */
	.ascii	"android/os/Parcel"
	.zero	75

	/* #59 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/os/Parcelable"
	.zero	71

	/* #60 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/os/Parcelable$Creator"
	.zero	63

	/* #61 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554712
	/* java_name */
	.ascii	"android/preference/PreferenceManager"
	.zero	56

	/* #62 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554859
	/* java_name */
	.ascii	"android/runtime/JavaProxyThrowable"
	.zero	58

	/* #63 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/text/Spannable"
	.zero	70

	/* #64 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/text/Spanned"
	.zero	72

	/* #65 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554708
	/* java_name */
	.ascii	"android/text/method/BaseMovementMethod"
	.zero	54

	/* #66 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/text/method/MovementMethod"
	.zero	58

	/* #67 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554711
	/* java_name */
	.ascii	"android/text/method/ScrollingMovementMethod"
	.zero	49

	/* #68 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/util/AttributeSet"
	.zero	67

	/* #69 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554697
	/* java_name */
	.ascii	"android/util/DisplayMetrics"
	.zero	65

	/* #70 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554700
	/* java_name */
	.ascii	"android/util/SparseArray"
	.zero	68

	/* #71 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554609
	/* java_name */
	.ascii	"android/view/ActionMode"
	.zero	69

	/* #72 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/ActionMode$Callback"
	.zero	60

	/* #73 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554613
	/* java_name */
	.ascii	"android/view/ActionProvider"
	.zero	65

	/* #74 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/ContextMenu"
	.zero	68

	/* #75 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/ContextMenu$ContextMenuInfo"
	.zero	52

	/* #76 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554615
	/* java_name */
	.ascii	"android/view/ContextThemeWrapper"
	.zero	60

	/* #77 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554616
	/* java_name */
	.ascii	"android/view/Display"
	.zero	72

	/* #78 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554617
	/* java_name */
	.ascii	"android/view/DragEvent"
	.zero	70

	/* #79 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554630
	/* java_name */
	.ascii	"android/view/InputEvent"
	.zero	69

	/* #80 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554642
	/* java_name */
	.ascii	"android/view/KeyEvent"
	.zero	71

	/* #81 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/KeyEvent$Callback"
	.zero	62

	/* #82 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554641
	/* java_name */
	.ascii	"android/view/KeyboardShortcutGroup"
	.zero	58

	/* #83 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554645
	/* java_name */
	.ascii	"android/view/LayoutInflater"
	.zero	65

	/* #84 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory"
	.zero	57

	/* #85 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory2"
	.zero	56

	/* #86 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/Menu"
	.zero	75

	/* #87 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554651
	/* java_name */
	.ascii	"android/view/MenuInflater"
	.zero	67

	/* #88 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/MenuItem"
	.zero	71

	/* #89 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/MenuItem$OnActionExpandListener"
	.zero	48

	/* #90 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/MenuItem$OnMenuItemClickListener"
	.zero	47

	/* #91 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554652
	/* java_name */
	.ascii	"android/view/MotionEvent"
	.zero	68

	/* #92 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554653
	/* java_name */
	.ascii	"android/view/SearchEvent"
	.zero	68

	/* #93 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/SubMenu"
	.zero	72

	/* #94 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554654
	/* java_name */
	.ascii	"android/view/View"
	.zero	75

	/* #95 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/View$OnClickListener"
	.zero	59

	/* #96 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/View$OnCreateContextMenuListener"
	.zero	47

	/* #97 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554662
	/* java_name */
	.ascii	"android/view/ViewGroup"
	.zero	70

	/* #98 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554663
	/* java_name */
	.ascii	"android/view/ViewGroup$LayoutParams"
	.zero	57

	/* #99 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554664
	/* java_name */
	.ascii	"android/view/ViewGroup$MarginLayoutParams"
	.zero	51

	/* #100 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/ViewManager"
	.zero	68

	/* #101 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/ViewParent"
	.zero	69

	/* #102 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554666
	/* java_name */
	.ascii	"android/view/ViewPropertyAnimator"
	.zero	59

	/* #103 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554667
	/* java_name */
	.ascii	"android/view/ViewTreeObserver"
	.zero	63

	/* #104 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnPreDrawListener"
	.zero	45

	/* #105 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554670
	/* java_name */
	.ascii	"android/view/Window"
	.zero	73

	/* #106 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/Window$Callback"
	.zero	64

	/* #107 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554674
	/* java_name */
	.ascii	"android/view/WindowInsets"
	.zero	67

	/* #108 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/WindowManager"
	.zero	66

	/* #109 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554638
	/* java_name */
	.ascii	"android/view/WindowManager$LayoutParams"
	.zero	53

	/* #110 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554675
	/* java_name */
	.ascii	"android/view/WindowMetrics"
	.zero	66

	/* #111 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554690
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEvent"
	.zero	47

	/* #112 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEventSource"
	.zero	41

	/* #113 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554691
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityRecord"
	.zero	46

	/* #114 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554686
	/* java_name */
	.ascii	"android/view/animation/Animation"
	.zero	60

	/* #115 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/view/animation/Interpolator"
	.zero	57

	/* #116 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/Adapter"
	.zero	70

	/* #117 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554587
	/* java_name */
	.ascii	"android/widget/AdapterView"
	.zero	66

	/* #118 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemSelectedListener"
	.zero	43

	/* #119 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554591
	/* java_name */
	.ascii	"android/widget/AutoCompleteTextView"
	.zero	57

	/* #120 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554592
	/* java_name */
	.ascii	"android/widget/Button"
	.zero	71

	/* #121 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554593
	/* java_name */
	.ascii	"android/widget/DatePicker"
	.zero	67

	/* #122 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/DatePicker$OnDateChangedListener"
	.zero	45

	/* #123 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554596
	/* java_name */
	.ascii	"android/widget/EditText"
	.zero	69

	/* #124 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554597
	/* java_name */
	.ascii	"android/widget/Filter"
	.zero	71

	/* #125 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/Filter$FilterListener"
	.zero	56

	/* #126 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554601
	/* java_name */
	.ascii	"android/widget/FrameLayout"
	.zero	66

	/* #127 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554602
	/* java_name */
	.ascii	"android/widget/HorizontalScrollView"
	.zero	57

	/* #128 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554605
	/* java_name */
	.ascii	"android/widget/ImageView"
	.zero	68

	/* #129 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"android/widget/SpinnerAdapter"
	.zero	63

	/* #130 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554608
	/* java_name */
	.ascii	"android/widget/TextView"
	.zero	69

	/* #131 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"androidx/activity/ComponentActivity"
	.zero	57

	/* #132 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar"
	.zero	60

	/* #133 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$LayoutParams"
	.zero	47

	/* #134 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$OnMenuVisibilityListener"
	.zero	35

	/* #135 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$OnNavigationListener"
	.zero	39

	/* #136 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554482
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$Tab"
	.zero	56

	/* #137 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$TabListener"
	.zero	48

	/* #138 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554489
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBarDrawerToggle"
	.zero	48

	/* #139 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBarDrawerToggle$Delegate"
	.zero	39

	/* #140 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBarDrawerToggle$DelegateProvider"
	.zero	31

	/* #141 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554494
	/* java_name */
	.ascii	"androidx/appcompat/app/AppCompatActivity"
	.zero	52

	/* #142 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/app/AppCompatCallback"
	.zero	52

	/* #143 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554495
	/* java_name */
	.ascii	"androidx/appcompat/app/AppCompatDelegate"
	.zero	52

	/* #144 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"androidx/appcompat/graphics/drawable/DrawerArrowDrawable"
	.zero	36

	/* #145 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554513
	/* java_name */
	.ascii	"androidx/appcompat/view/ActionMode"
	.zero	58

	/* #146 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/view/ActionMode$Callback"
	.zero	49

	/* #147 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554517
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuBuilder"
	.zero	52

	/* #148 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuBuilder$Callback"
	.zero	43

	/* #149 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554526
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuItemImpl"
	.zero	51

	/* #150 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuPresenter"
	.zero	50

	/* #151 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuPresenter$Callback"
	.zero	41

	/* #152 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuView"
	.zero	55

	/* #153 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554527
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/SubMenuBuilder"
	.zero	49

	/* #154 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554508
	/* java_name */
	.ascii	"androidx/appcompat/widget/AppCompatAutoCompleteTextView"
	.zero	37

	/* #155 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/widget/DecorToolbar"
	.zero	54

	/* #156 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554511
	/* java_name */
	.ascii	"androidx/appcompat/widget/ScrollingTabContainerView"
	.zero	41

	/* #157 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554512
	/* java_name */
	.ascii	"androidx/appcompat/widget/ScrollingTabContainerView$VisibilityAnimListener"
	.zero	18

	/* #158 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554499
	/* java_name */
	.ascii	"androidx/appcompat/widget/Toolbar"
	.zero	59

	/* #159 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/appcompat/widget/Toolbar$OnMenuItemClickListener"
	.zero	35

	/* #160 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554500
	/* java_name */
	.ascii	"androidx/appcompat/widget/Toolbar_NavigationOnClickEventDispatcher"
	.zero	26

	/* #161 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"androidx/coordinatorlayout/widget/CoordinatorLayout"
	.zero	41

	/* #162 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior"
	.zero	32

	/* #163 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"androidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams"
	.zero	28

	/* #164 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554516
	/* java_name */
	.ascii	"androidx/core/app/ActivityCompat"
	.zero	60

	/* #165 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/app/ActivityCompat$OnRequestPermissionsResultCallback"
	.zero	25

	/* #166 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/app/ActivityCompat$PermissionCompatDelegate"
	.zero	35

	/* #167 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/app/ActivityCompat$RequestPermissionsRequestCodeValidator"
	.zero	21

	/* #168 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554523
	/* java_name */
	.ascii	"androidx/core/app/ComponentActivity"
	.zero	57

	/* #169 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554524
	/* java_name */
	.ascii	"androidx/core/app/ComponentActivity$ExtraData"
	.zero	47

	/* #170 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554525
	/* java_name */
	.ascii	"androidx/core/app/SharedElementCallback"
	.zero	53

	/* #171 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/app/SharedElementCallback$OnSharedElementsReadyListener"
	.zero	23

	/* #172 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554529
	/* java_name */
	.ascii	"androidx/core/app/TaskStackBuilder"
	.zero	58

	/* #173 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/app/TaskStackBuilder$SupportParentable"
	.zero	40

	/* #174 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554514
	/* java_name */
	.ascii	"androidx/core/content/ContextCompat"
	.zero	57

	/* #175 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554515
	/* java_name */
	.ascii	"androidx/core/content/pm/PackageInfoCompat"
	.zero	50

	/* #176 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554513
	/* java_name */
	.ascii	"androidx/core/graphics/Insets"
	.zero	63

	/* #177 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/internal/view/SupportMenu"
	.zero	53

	/* #178 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/internal/view/SupportMenuItem"
	.zero	49

	/* #179 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"androidx/core/view/ActionProvider"
	.zero	59

	/* #180 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/ActionProvider$SubUiVisibilityListener"
	.zero	35

	/* #181 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/ActionProvider$VisibilityListener"
	.zero	40

	/* #182 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554490
	/* java_name */
	.ascii	"androidx/core/view/DisplayCutoutCompat"
	.zero	54

	/* #183 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554491
	/* java_name */
	.ascii	"androidx/core/view/DragAndDropPermissionsCompat"
	.zero	45

	/* #184 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554504
	/* java_name */
	.ascii	"androidx/core/view/KeyEventDispatcher"
	.zero	55

	/* #185 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/KeyEventDispatcher$Component"
	.zero	45

	/* #186 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/NestedScrollingParent"
	.zero	52

	/* #187 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/NestedScrollingParent2"
	.zero	51

	/* #188 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/NestedScrollingParent3"
	.zero	51

	/* #189 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/TintableBackgroundView"
	.zero	51

	/* #190 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554507
	/* java_name */
	.ascii	"androidx/core/view/ViewPropertyAnimatorCompat"
	.zero	47

	/* #191 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/ViewPropertyAnimatorListener"
	.zero	45

	/* #192 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/core/view/ViewPropertyAnimatorUpdateListener"
	.zero	39

	/* #193 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554508
	/* java_name */
	.ascii	"androidx/core/view/WindowInsetsCompat"
	.zero	55

	/* #194 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/customview/widget/Openable"
	.zero	57

	/* #195 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"androidx/drawerlayout/widget/DrawerLayout"
	.zero	51

	/* #196 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/drawerlayout/widget/DrawerLayout$DrawerListener"
	.zero	36

	/* #197 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"androidx/fragment/app/Fragment"
	.zero	62

	/* #198 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"androidx/fragment/app/Fragment$SavedState"
	.zero	51

	/* #199 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554467
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentActivity"
	.zero	54

	/* #200 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentFactory"
	.zero	55

	/* #201 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentManager"
	.zero	55

	/* #202 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentManager$BackStackEntry"
	.zero	40

	/* #203 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks"
	.zero	28

	/* #204 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentManager$OnBackStackChangedListener"
	.zero	28

	/* #205 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554482
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentTransaction"
	.zero	51

	/* #206 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/lifecycle/HasDefaultViewModelProviderFactory"
	.zero	39

	/* #207 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"androidx/lifecycle/Lifecycle"
	.zero	64

	/* #208 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"androidx/lifecycle/Lifecycle$State"
	.zero	58

	/* #209 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/lifecycle/LifecycleObserver"
	.zero	56

	/* #210 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/lifecycle/LifecycleOwner"
	.zero	59

	/* #211 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"androidx/lifecycle/LiveData"
	.zero	65

	/* #212 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/lifecycle/Observer"
	.zero	65

	/* #213 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"androidx/lifecycle/ViewModelProvider"
	.zero	56

	/* #214 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/lifecycle/ViewModelProvider$Factory"
	.zero	48

	/* #215 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"androidx/lifecycle/ViewModelStore"
	.zero	59

	/* #216 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/lifecycle/ViewModelStoreOwner"
	.zero	54

	/* #217 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"androidx/loader/app/LoaderManager"
	.zero	59

	/* #218 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/loader/app/LoaderManager$LoaderCallbacks"
	.zero	43

	/* #219 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"androidx/loader/content/Loader"
	.zero	62

	/* #220 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/loader/content/Loader$OnLoadCanceledListener"
	.zero	39

	/* #221 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/loader/content/Loader$OnLoadCompleteListener"
	.zero	39

	/* #222 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"androidx/savedstate/SavedStateRegistry"
	.zero	54

	/* #223 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/savedstate/SavedStateRegistry$SavedStateProvider"
	.zero	35

	/* #224 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"androidx/savedstate/SavedStateRegistryOwner"
	.zero	49

	/* #225 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"com/google/android/material/behavior/SwipeDismissBehavior"
	.zero	35

	/* #226 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"com/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener"
	.zero	17

	/* #227 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"com/google/android/material/snackbar/BaseTransientBottomBar"
	.zero	33

	/* #228 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback"
	.zero	20

	/* #229 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"com/google/android/material/snackbar/BaseTransientBottomBar$Behavior"
	.zero	24

	/* #230 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"com/google/android/material/snackbar/ContentViewCallback"
	.zero	36

	/* #231 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/google/android/material/snackbar/Snackbar"
	.zero	47

	/* #232 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"com/google/android/material/snackbar/Snackbar$Callback"
	.zero	38

	/* #233 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"com/google/android/material/snackbar/Snackbar_SnackbarActionClickImplementor"
	.zero	16

	/* #234 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"com/google/common/util/concurrent/ListenableFuture"
	.zero	42

	/* #235 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"crc64903dcea04fdc7c22/MainActivity"
	.zero	58

	/* #236 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"crc64a0e0a82d0db9a07d/ActivityLifecycleContextListener"
	.zero	38

	/* #237 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555031
	/* java_name */
	.ascii	"java/io/BufferedReader"
	.zero	70

	/* #238 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/io/Closeable"
	.zero	75

	/* #239 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555032
	/* java_name */
	.ascii	"java/io/File"
	.zero	80

	/* #240 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555033
	/* java_name */
	.ascii	"java/io/FileDescriptor"
	.zero	70

	/* #241 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555034
	/* java_name */
	.ascii	"java/io/FileInputStream"
	.zero	69

	/* #242 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555035
	/* java_name */
	.ascii	"java/io/FileOutputStream"
	.zero	68

	/* #243 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/io/Flushable"
	.zero	75

	/* #244 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555044
	/* java_name */
	.ascii	"java/io/IOException"
	.zero	73

	/* #245 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555040
	/* java_name */
	.ascii	"java/io/InputStream"
	.zero	73

	/* #246 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555042
	/* java_name */
	.ascii	"java/io/InputStreamReader"
	.zero	67

	/* #247 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555043
	/* java_name */
	.ascii	"java/io/InterruptedIOException"
	.zero	62

	/* #248 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555047
	/* java_name */
	.ascii	"java/io/OutputStream"
	.zero	72

	/* #249 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555049
	/* java_name */
	.ascii	"java/io/PrintWriter"
	.zero	73

	/* #250 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555050
	/* java_name */
	.ascii	"java/io/Reader"
	.zero	78

	/* #251 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/io/Serializable"
	.zero	72

	/* #252 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555052
	/* java_name */
	.ascii	"java/io/StringWriter"
	.zero	72

	/* #253 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555053
	/* java_name */
	.ascii	"java/io/Writer"
	.zero	78

	/* #254 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/Appendable"
	.zero	72

	/* #255 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/AutoCloseable"
	.zero	69

	/* #256 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554969
	/* java_name */
	.ascii	"java/lang/Boolean"
	.zero	75

	/* #257 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554970
	/* java_name */
	.ascii	"java/lang/Byte"
	.zero	78

	/* #258 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/CharSequence"
	.zero	70

	/* #259 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554971
	/* java_name */
	.ascii	"java/lang/Character"
	.zero	73

	/* #260 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554972
	/* java_name */
	.ascii	"java/lang/Class"
	.zero	77

	/* #261 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554973
	/* java_name */
	.ascii	"java/lang/ClassCastException"
	.zero	64

	/* #262 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554974
	/* java_name */
	.ascii	"java/lang/ClassLoader"
	.zero	71

	/* #263 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554976
	/* java_name */
	.ascii	"java/lang/ClassNotFoundException"
	.zero	60

	/* #264 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/Cloneable"
	.zero	73

	/* #265 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/Comparable"
	.zero	72

	/* #266 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554977
	/* java_name */
	.ascii	"java/lang/Double"
	.zero	76

	/* #267 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554978
	/* java_name */
	.ascii	"java/lang/Enum"
	.zero	78

	/* #268 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554980
	/* java_name */
	.ascii	"java/lang/Error"
	.zero	77

	/* #269 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554981
	/* java_name */
	.ascii	"java/lang/Exception"
	.zero	73

	/* #270 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554982
	/* java_name */
	.ascii	"java/lang/Float"
	.zero	77

	/* #271 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554996
	/* java_name */
	.ascii	"java/lang/IllegalArgumentException"
	.zero	58

	/* #272 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554997
	/* java_name */
	.ascii	"java/lang/IllegalStateException"
	.zero	61

	/* #273 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554998
	/* java_name */
	.ascii	"java/lang/IndexOutOfBoundsException"
	.zero	57

	/* #274 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554999
	/* java_name */
	.ascii	"java/lang/Integer"
	.zero	75

	/* #275 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/Iterable"
	.zero	74

	/* #276 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555004
	/* java_name */
	.ascii	"java/lang/LinkageError"
	.zero	70

	/* #277 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555005
	/* java_name */
	.ascii	"java/lang/Long"
	.zero	78

	/* #278 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555006
	/* java_name */
	.ascii	"java/lang/NoClassDefFoundError"
	.zero	62

	/* #279 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555007
	/* java_name */
	.ascii	"java/lang/NullPointerException"
	.zero	62

	/* #280 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555008
	/* java_name */
	.ascii	"java/lang/Number"
	.zero	76

	/* #281 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555010
	/* java_name */
	.ascii	"java/lang/Object"
	.zero	76

	/* #282 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/Readable"
	.zero	74

	/* #283 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555011
	/* java_name */
	.ascii	"java/lang/ReflectiveOperationException"
	.zero	54

	/* #284 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/Runnable"
	.zero	74

	/* #285 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555012
	/* java_name */
	.ascii	"java/lang/RuntimeException"
	.zero	66

	/* #286 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555013
	/* java_name */
	.ascii	"java/lang/SecurityException"
	.zero	65

	/* #287 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555014
	/* java_name */
	.ascii	"java/lang/Short"
	.zero	77

	/* #288 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555015
	/* java_name */
	.ascii	"java/lang/String"
	.zero	76

	/* #289 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555017
	/* java_name */
	.ascii	"java/lang/Thread"
	.zero	76

	/* #290 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555019
	/* java_name */
	.ascii	"java/lang/Throwable"
	.zero	73

	/* #291 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555020
	/* java_name */
	.ascii	"java/lang/UnsupportedOperationException"
	.zero	53

	/* #292 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/annotation/Annotation"
	.zero	61

	/* #293 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/reflect/AnnotatedElement"
	.zero	58

	/* #294 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/reflect/GenericDeclaration"
	.zero	56

	/* #295 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/reflect/Type"
	.zero	70

	/* #296 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/lang/reflect/TypeVariable"
	.zero	62

	/* #297 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554950
	/* java_name */
	.ascii	"java/net/ConnectException"
	.zero	67

	/* #298 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554951
	/* java_name */
	.ascii	"java/net/HttpURLConnection"
	.zero	66

	/* #299 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554953
	/* java_name */
	.ascii	"java/net/InetSocketAddress"
	.zero	66

	/* #300 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554954
	/* java_name */
	.ascii	"java/net/ProtocolException"
	.zero	66

	/* #301 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554955
	/* java_name */
	.ascii	"java/net/Proxy"
	.zero	78

	/* #302 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554956
	/* java_name */
	.ascii	"java/net/Proxy$Type"
	.zero	73

	/* #303 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554957
	/* java_name */
	.ascii	"java/net/ProxySelector"
	.zero	70

	/* #304 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554959
	/* java_name */
	.ascii	"java/net/SocketAddress"
	.zero	70

	/* #305 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554961
	/* java_name */
	.ascii	"java/net/SocketException"
	.zero	68

	/* #306 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554962
	/* java_name */
	.ascii	"java/net/SocketTimeoutException"
	.zero	61

	/* #307 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554964
	/* java_name */
	.ascii	"java/net/URI"
	.zero	80

	/* #308 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554965
	/* java_name */
	.ascii	"java/net/URL"
	.zero	80

	/* #309 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554966
	/* java_name */
	.ascii	"java/net/URLConnection"
	.zero	70

	/* #310 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554963
	/* java_name */
	.ascii	"java/net/UnknownServiceException"
	.zero	60

	/* #311 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554923
	/* java_name */
	.ascii	"java/nio/Buffer"
	.zero	77

	/* #312 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554925
	/* java_name */
	.ascii	"java/nio/ByteBuffer"
	.zero	73

	/* #313 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554927
	/* java_name */
	.ascii	"java/nio/CharBuffer"
	.zero	73

	/* #314 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/nio/channels/ByteChannel"
	.zero	63

	/* #315 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/nio/channels/Channel"
	.zero	67

	/* #316 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554930
	/* java_name */
	.ascii	"java/nio/channels/FileChannel"
	.zero	63

	/* #317 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/nio/channels/GatheringByteChannel"
	.zero	54

	/* #318 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/nio/channels/InterruptibleChannel"
	.zero	54

	/* #319 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/nio/channels/ReadableByteChannel"
	.zero	55

	/* #320 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/nio/channels/ScatteringByteChannel"
	.zero	53

	/* #321 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/nio/channels/SeekableByteChannel"
	.zero	55

	/* #322 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/nio/channels/WritableByteChannel"
	.zero	55

	/* #323 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554948
	/* java_name */
	.ascii	"java/nio/channels/spi/AbstractInterruptibleChannel"
	.zero	42

	/* #324 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554910
	/* java_name */
	.ascii	"java/security/KeyStore"
	.zero	70

	/* #325 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/security/KeyStore$LoadStoreParameter"
	.zero	51

	/* #326 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/security/KeyStore$ProtectionParameter"
	.zero	50

	/* #327 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/security/Principal"
	.zero	69

	/* #328 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554915
	/* java_name */
	.ascii	"java/security/SecureRandom"
	.zero	66

	/* #329 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554916
	/* java_name */
	.ascii	"java/security/cert/Certificate"
	.zero	62

	/* #330 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554918
	/* java_name */
	.ascii	"java/security/cert/CertificateFactory"
	.zero	55

	/* #331 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554921
	/* java_name */
	.ascii	"java/security/cert/X509Certificate"
	.zero	58

	/* #332 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/security/cert/X509Extension"
	.zero	60

	/* #333 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554851
	/* java_name */
	.ascii	"java/util/ArrayList"
	.zero	73

	/* #334 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554840
	/* java_name */
	.ascii	"java/util/Collection"
	.zero	72

	/* #335 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/Comparator"
	.zero	72

	/* #336 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/Enumeration"
	.zero	71

	/* #337 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554842
	/* java_name */
	.ascii	"java/util/HashMap"
	.zero	75

	/* #338 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554860
	/* java_name */
	.ascii	"java/util/HashSet"
	.zero	75

	/* #339 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/Iterator"
	.zero	74

	/* #340 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554891
	/* java_name */
	.ascii	"java/util/Random"
	.zero	76

	/* #341 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/Spliterator"
	.zero	71

	/* #342 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/concurrent/Executor"
	.zero	63

	/* #343 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/concurrent/Future"
	.zero	65

	/* #344 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554907
	/* java_name */
	.ascii	"java/util/concurrent/TimeUnit"
	.zero	63

	/* #345 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/function/Consumer"
	.zero	65

	/* #346 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/function/Function"
	.zero	65

	/* #347 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/function/ToDoubleFunction"
	.zero	57

	/* #348 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/function/ToIntFunction"
	.zero	60

	/* #349 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"java/util/function/ToLongFunction"
	.zero	59

	/* #350 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554559
	/* java_name */
	.ascii	"javax/net/SocketFactory"
	.zero	69

	/* #351 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"javax/net/ssl/HostnameVerifier"
	.zero	62

	/* #352 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554561
	/* java_name */
	.ascii	"javax/net/ssl/HttpsURLConnection"
	.zero	60

	/* #353 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"javax/net/ssl/KeyManager"
	.zero	68

	/* #354 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554575
	/* java_name */
	.ascii	"javax/net/ssl/KeyManagerFactory"
	.zero	61

	/* #355 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554576
	/* java_name */
	.ascii	"javax/net/ssl/SSLContext"
	.zero	68

	/* #356 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"javax/net/ssl/SSLSession"
	.zero	68

	/* #357 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"javax/net/ssl/SSLSessionContext"
	.zero	61

	/* #358 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554577
	/* java_name */
	.ascii	"javax/net/ssl/SSLSocketFactory"
	.zero	62

	/* #359 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"javax/net/ssl/TrustManager"
	.zero	66

	/* #360 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554579
	/* java_name */
	.ascii	"javax/net/ssl/TrustManagerFactory"
	.zero	59

	/* #361 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"javax/net/ssl/X509TrustManager"
	.zero	62

	/* #362 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554558
	/* java_name */
	.ascii	"javax/security/auth/Subject"
	.zero	65

	/* #363 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554554
	/* java_name */
	.ascii	"javax/security/cert/Certificate"
	.zero	61

	/* #364 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554556
	/* java_name */
	.ascii	"javax/security/cert/X509Certificate"
	.zero	57

	/* #365 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555077
	/* java_name */
	.ascii	"mono/android/TypeManager"
	.zero	68

	/* #366 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554773
	/* java_name */
	.ascii	"mono/android/app/DatePickerDialog_OnDateSetListenerImplementor"
	.zero	30

	/* #367 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554791
	/* java_name */
	.ascii	"mono/android/content/DialogInterface_OnClickListenerImplementor"
	.zero	29

	/* #368 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554836
	/* java_name */
	.ascii	"mono/android/runtime/InputStreamAdapter"
	.zero	53

	/* #369 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"mono/android/runtime/JavaArray"
	.zero	62

	/* #370 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554857
	/* java_name */
	.ascii	"mono/android/runtime/JavaObject"
	.zero	61

	/* #371 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554875
	/* java_name */
	.ascii	"mono/android/runtime/OutputStreamAdapter"
	.zero	52

	/* #372 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554657
	/* java_name */
	.ascii	"mono/android/view/View_OnClickListenerImplementor"
	.zero	43

	/* #373 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"mono/androidx/appcompat/app/ActionBar_OnMenuVisibilityListenerImplementor"
	.zero	19

	/* #374 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554505
	/* java_name */
	.ascii	"mono/androidx/appcompat/widget/Toolbar_OnMenuItemClickListenerImplementor"
	.zero	19

	/* #375 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554480
	/* java_name */
	.ascii	"mono/androidx/core/view/ActionProvider_SubUiVisibilityListenerImplementor"
	.zero	19

	/* #376 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554484
	/* java_name */
	.ascii	"mono/androidx/core/view/ActionProvider_VisibilityListenerImplementor"
	.zero	24

	/* #377 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"mono/androidx/drawerlayout/widget/DrawerLayout_DrawerListenerImplementor"
	.zero	20

	/* #378 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"mono/androidx/fragment/app/FragmentManager_OnBackStackChangedListenerImplementor"
	.zero	12

	/* #379 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"mono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor"
	.zero	1

	/* #380 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33555018
	/* java_name */
	.ascii	"mono/java/lang/RunnableImplementor"
	.zero	58

	/* #381 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554553
	/* java_name */
	.ascii	"xamarin/android/net/OldAndroidSSLSocketFactory"
	.zero	46

	.size	map_java, 38200
/* Java to managed map: END */


/* java_name_width: START */
	.section	.rodata.java_name_width,"a",@progbits
	.type	java_name_width, @object
	.p2align	2
	.global	java_name_width
java_name_width:
	.size	java_name_width, 4
	.word	92
/* java_name_width: END */
