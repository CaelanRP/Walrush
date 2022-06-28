
Shader "VFX/Pandavfx_v2.1"
{
	Properties
	{
		[Enum(UnityEngine.Rendering.CullMode)]_Cullmode("Cullmode", Float) = 0
		[KeywordEnum(Normal,Polar,Cylinder)] _MaskTexUVS("MaskTexUVS", Float) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)]_Ztest("Ztest", Float) = 4
		[KeywordEnum(Normal,Polar,Cylinder)] _DissolveTexUVS("DissolveTexUVS", Float) = 0
		[Enum(UnityEngine.Rendering.BlendMode)]_Scr("Scr", Float) = 5
		_TexCenter("TexCenter", Vector) = (0,0,0,0)
		[Enum(UnityEngine.Rendering.BlendMode)]_Dst("Dst", Float) = 10
		[KeywordEnum(Normal,Polar,Cylinder)] _MainTexUVS("MainTexUVS", Float) = 0
		[KeywordEnum(X,Y,Z)] _Face("Face", Float) = 1
		[HideInInspector]_AddTex_ST("AddTex_ST", Vector) = (1,1,0,0)
		[HideInInspector]_MainTex_ST("MainTex_ST", Vector) = (1,1,0,0)
		[HideInInspector]_VTOTex_ST("VTOTex_ST", Vector) = (1,1,0,0)
		[HideInInspector]_DistortTex_ST("DistortTex_ST", Vector) = (1,1,0,0)
		[HideInInspector]_DissloveTexPlus_ST("DissloveTexPlus_ST", Vector) = (1,1,0,0)
		[HideInInspector]_DissloveTex_ST("DissloveTex_ST", Vector) = (1,1,0,0)
		[HideInInspector]_VTOMaskTex_ST("VTOMaskTex_ST", Vector) = (1,1,0,0)
		[HideInInspector]_MaskTex_ST("MaskTex_ST", Vector) = (1,1,0,0)
		_MainTex("MainTex", 2D) = "white" {}
		_MainAlpha("MainAlpha", Range( 0 , 100)) = 1
		[HDR]_MainColor("MainColor", Color) = (1,1,1,1)
		_AddTexUspeed("AddTexUspeed", Float) = 0
		_MainTex_Uspeed("MainTex_Uspeed", Float) = 0
		_AddTexVspeed("AddTexVspeed", Float) = 0
		_MainTex_Vspeed("MainTex_Vspeed", Float) = 0
		_MaskTex("MaskTex", 2D) = "white" {}
		_DistortTex("DistortTex", 2D) = "white" {}
		[Enum(off,0,on,1)]_DistortAddTex("DistortAddTex", Float) = 1
		[Enum(off,0,on,1)]_DistortMainTex("DistortMainTex", Float) = 1
		[Enum(off,0,on,1)]_DistortMask("DistortMask", Float) = 0
		[Enum(off,0,on,1)]_DistortDisTex("DistortDisTex", Float) = 0
		_DistortFactor("DistortFactor", Range( 0 , 3)) = 0
		_DistortTex_Uspeed("DistortTex_Uspeed", Float) = 0
		_DistortTex_Vspeed("DistortTex_Vspeed", Float) = 0
		_DissloveTexPlus("DissloveTexPlus", 2D) = "white" {}
		_DissloveTex("DissloveTex", 2D) = "white" {}
		_DIssloveFactor("DIssloveFactor", Range( 0 , 1)) = 0.5
		_DIssloveWide("DIssloveWide", Range( 0 , 1)) = 0.1
		_DIssloveSoft("DIssloveSoft", Range( 0 , 1)) = 0.5
		[HDR]_DIssloveColor("DIssloveColor", Color) = (1,1,1,1)
		_DisTex_Uspeed("DisTex_Uspeed", Float) = 0
		_DisTex_Vspeed("DisTex_Vspeed", Float) = 0
		_VTOTex("VTOTex", 2D) = "white" {}
		_VTOFactor("VTOFactor", Float) = 0
		_VTOTex_Uspeed("VTOTex_Uspeed", Float) = 0
		_VTOTex_Vspeed("VTOTex_Vspeed", Float) = 0
		_VTOMaskTex("VTOMaskTex", 2D) = "white" {}
		_fnl_power("fnl_power", Range( 1 , 10)) = 1
		_fnl_sacle("fnl_sacle", Range( 0 , 1)) = 0
		[HDR]_fnl_color("fnl_color", Color) = (1,1,1,0)
		_softFacotr("softFacotr", Range( 0 , 20)) = 1
		_DepthfadeFactor("DepthfadeFactor", Float) = 1
		[Toggle]_MainTex_ar("MainTex_a/r", Float) = 0
		[Toggle]_CustomdataMainTexUV("CustomdataMainTexUV", Float) = 0
		[Toggle]_MaskAlphaRA("MaskAlphaRA", Float) = 0
		[Toggle]_CustomdataMaskUV("CustomdataMaskUV", Float) = 0
		_Mask_scale("Mask_scale", Float) = 1
		[Toggle]_AlphaAdd("AlphaAdd", Float) = 0
		_MainTex_rotat("MainTex_rotat", Range( 0 , 360)) = 0
		_AddTexRo("AddTexRo", Range( 0 , 360)) = 0
		_VTOR("VTOR", Range( 0 , 360)) = 0
		_VTOMaskR("VTOMaskR", Range( 0 , 360)) = 0
		_DissolvePlusR("DissolvePlusR", Range( 0 , 360)) = 0
		_DIssolve_rotat("DIssolve_rotat", Range( 0 , 360)) = 0
		[Toggle]_CustomdataDis("CustomdataDis", Float) = 0
		[Toggle]_FNLfanxiangkaiguan("FNLfanxiangkaiguan", Float) = 0
		[Toggle]_ToggleSwitch0("Toggle Switch0", Float) = 0
		[Toggle]_Depthfadeon("Depthfadeon", Float) = 0
		[Toggle]_screenVTOon("screenVTOon", Float) = 0
		_Mask_Uspeed("Mask_Uspeed", Float) = 0
		_Mask_rotat("Mask_rotat", Range( 0 , 360)) = 0
		_Mask_Vspeed("Mask_Vspeed", Float) = 0
		[Toggle]_soft_sting("soft_sting", Float) = 0
		[Toggle]_sot_sting_A("sot_sting_A", Float) = 0
		[Toggle]_MaintexCV("MaintexCV", Float) = 0
		[Toggle]_AddTexCV("AddTexCV", Float) = 0
		[Toggle]_AddTexC("AddTexC", Float) = 0
		[Toggle]_MaintexC("MaintexC", Float) = 0
		[Toggle]_MaskCV("MaskCV", Float) = 0
		[Toggle]_MaskC("MaskC", Float) = 0
		[Toggle]_DissolvePlusCV("DissolvePlusCV", Float) = 0
		[Toggle]_DissolveCV("DissolveCV", Float) = 0
		[Toggle]_DissolveC("DissolveC", Float) = 0
		[Toggle]_DissolvePlusC("DissolvePlusC", Float) = 0
		[Toggle]_DissolvePlusAR("DissolvePlusAR", Float) = 1
		[Toggle]_DissolveAR("DissolveAR", Float) = 1
		[Toggle]_VTOAR("VTOAR", Float) = 1
		[Toggle]_VTOMaskAR("VTOMaskAR", Float) = 1
		[Toggle]_VTOMaskCV("VTOMaskCV", Float) = 0
		[Toggle]_VTOMaskC("VTOMaskC", Float) = 0
		[Toggle]_VTOC("VTOC", Float) = 0
		[Toggle]_VTOCV("VTOCV", Float) = 0
		_qubaohedu("qubaohedu", Range( 0 , 1)) = 0
		[HDR]_DepthColor("DepthColor", Color) = (0,0,0,0)
		_Zwrite("Zwrite", Float) = 0
		[Enum(Option1,0,Option2,1)]_DepthF("DepthF", Float) = 0
		_Dir("Dir", Vector) = (0,0,0,0)
		_AddTex("AddTex", 2D) = "white" {}
		[HDR]_BackFaceColor("BackFaceColor", Color) = (1,1,1,0)
		[Toggle]_IfMaskColor("IfMaskColor", Float) = 0
		[HideInInspector] _texcoord2( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] _tex4coord2( "", 2D ) = "white" {}
		[Enum(Option1,0,Option2,1)]_CustomDistort("CustomDistort", Float) = 0
		[HideInInspector] _tex4coord3( "", 2D ) = "white" {}
		[HideInInspector] _texcoord3( "", 2D ) = "white" {}
		[HDR]_AddTexColor("AddTexColor", Color) = (0,0,0,0)
		[Toggle]_AddTexChanel("AddTexChanel", Float) = 0
		_AddTexBlend("AddTexBlend", Range( 0 , 1)) = 0
		[KeywordEnum(Lerp,Add)] _AddTexBlendMode("AddTexBlendMode", Float) = 0
		[Toggle]_IfAddTex("IfAddTex", Float) = 0
		[Toggle]_IfDissolvePlus("IfDissolvePlus", Float) = 0
		_DissolveTexDivide("DissolveTexDivide", Range( 1 , 10)) = 1
		[Enum(Option1,0,Option2,1)]_CustomdataDisT("CustomdataDisT", Float) = 0
		_CenterU("CenterU", Float) = 0.5
		_CenterV("CenterV", Float) = 0.5
		[Enum(off,0,on,1)]_ScreenAsMain("ScreenAsMain", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IsEmissive" = "true"  }
		Cull [_Cullmode]
		ZWrite [_Zwrite]
		ZTest [_Ztest]
		Blend [_Scr] [_Dst]
		
		GrabPass{ }
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityCG.cginc"
		#pragma target 5.0
		#pragma multi_compile_local _MAINTEXUVS_NORMAL _MAINTEXUVS_POLAR _MAINTEXUVS_CYLINDER
		#pragma multi_compile_local _FACE_X _FACE_Y _FACE_Z
		#pragma multi_compile_local _MASKTEXUVS_NORMAL _MASKTEXUVS_POLAR _MASKTEXUVS_CYLINDER
		#pragma multi_compile_local _DISSOLVETEXUVS_NORMAL _DISSOLVETEXUVS_POLAR _DISSOLVETEXUVS_CYLINDER
		#pragma multi_compile_local _ADDTEXBLENDMODE_LERP _ADDTEXBLENDMODE_ADD
		#if defined(UNITY_STEREO_INSTANCING_ENABLED) || defined(UNITY_STEREO_MULTIVIEW_ENABLED)
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex);
		#else
		#define ASE_DECLARE_SCREENSPACE_TEXTURE(tex) UNITY_DECLARE_SCREENSPACE_TEXTURE(tex)
		#endif
		#pragma surface surf Unlit keepalpha noshadow noambient nolightmap  nofog nometa noforwardadd vertex:vertexDataFunc 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float2 uv_texcoord;
			float3 worldPos;
			float4 uv3_tex4coord3;
			float2 uv3_texcoord3;
			float4 vertexColor : COLOR;
			float2 uv2_texcoord2;
			float4 screenPos;
			float4 uv2_tex4coord2;
			float3 viewDir;
			float3 worldNormal;
			float4 screenPosition88;
			half ASEVFace : VFACE;
		};

		uniform float _Dst;
		uniform float _Zwrite;
		uniform float _Cullmode;
		uniform float _Ztest;
		uniform float _Scr;
		uniform float _screenVTOon;
		uniform float _VTOAR;
		uniform sampler2D _VTOTex;
		uniform float _VTOC;
		uniform float _VTOTex_Uspeed;
		uniform float _VTOTex_Vspeed;
		uniform float4 _VTOTex_ST;
		uniform float _CenterU;
		uniform float _CenterV;
		uniform float4 _TexCenter;
		uniform float _VTOR;
		uniform float _VTOCV;
		uniform float _ToggleSwitch0;
		uniform float _VTOFactor;
		uniform float _VTOMaskAR;
		uniform sampler2D _VTOMaskTex;
		uniform float _VTOMaskC;
		uniform float4 _VTOMaskTex_ST;
		uniform float _VTOMaskR;
		uniform float _VTOMaskCV;
		uniform float _AlphaAdd;
		uniform float _Mask_scale;
		uniform float _MaskAlphaRA;
		uniform sampler2D _MaskTex;
		uniform float _MaskC;
		uniform float _Mask_Uspeed;
		uniform float _Mask_Vspeed;
		uniform float4 _MaskTex_ST;
		uniform sampler2D _DistortTex;
		uniform float _DistortTex_Uspeed;
		uniform float _DistortTex_Vspeed;
		uniform float4 _DistortTex_ST;
		uniform float _DistortFactor;
		uniform float _CustomDistort;
		uniform float _DistortMask;
		uniform float _CustomdataMaskUV;
		uniform float _Mask_rotat;
		uniform float _MaskCV;
		uniform float _CustomdataDisT;
		uniform float _MainTex_ar;
		uniform sampler2D _MainTex;
		uniform float _MaintexC;
		uniform float _MainTex_Uspeed;
		uniform float _MainTex_Vspeed;
		uniform float _CustomdataMainTexUV;
		uniform float4 _MainTex_ST;
		uniform float _DistortMainTex;
		uniform float _MainTex_rotat;
		uniform float _MaintexCV;
		ASE_DECLARE_SCREENSPACE_TEXTURE( _GrabTexture )
		uniform float _ScreenAsMain;
		uniform float4 _MainColor;
		uniform float _MainAlpha;
		uniform float _sot_sting_A;
		uniform float _DIssloveSoft;
		uniform float _CustomdataDis;
		uniform float _DIssloveFactor;
		uniform float _DissolveAR;
		uniform sampler2D _DissloveTex;
		uniform float _DissolveC;
		uniform float _DisTex_Uspeed;
		uniform float _DisTex_Vspeed;
		uniform float4 _DissloveTex_ST;
		uniform float _DistortDisTex;
		uniform float _DIssolve_rotat;
		uniform float _DissolveCV;
		uniform float _DissolveTexDivide;
		uniform float _IfDissolvePlus;
		uniform float _DissolvePlusAR;
		uniform sampler2D _DissloveTexPlus;
		uniform float _DissolvePlusC;
		uniform float4 _DissloveTexPlus_ST;
		uniform float _DissolvePlusR;
		uniform float _DissolvePlusCV;
		uniform float _DIssloveWide;
		uniform float _FNLfanxiangkaiguan;
		uniform float _softFacotr;
		uniform float _Depthfadeon;
		UNITY_DECLARE_DEPTH_TEXTURE( _CameraDepthTexture );
		uniform float4 _CameraDepthTexture_TexelSize;
		uniform float _DepthfadeFactor;
		uniform float _DepthF;
		uniform float4 _DepthColor;
		uniform float3 _Dir;
		uniform float _fnl_sacle;
		uniform float _fnl_power;
		uniform float4 _fnl_color;
		uniform float _soft_sting;
		uniform float _IfAddTex;
		uniform float _IfMaskColor;
		uniform float _AddTexChanel;
		uniform float4 _AddTexColor;
		uniform sampler2D _AddTex;
		uniform float _AddTexC;
		uniform float _AddTexUspeed;
		uniform float _AddTexVspeed;
		uniform float4 _AddTex_ST;
		uniform float _DistortAddTex;
		uniform float _AddTexRo;
		uniform float _AddTexCV;
		uniform float _AddTexBlend;
		uniform float4 _DIssloveColor;
		uniform float4 _BackFaceColor;
		uniform float _qubaohedu;


		inline float4 ASE_ComputeGrabScreenPos( float4 pos )
		{
			#if UNITY_UV_STARTS_AT_TOP
			float scale = -1.0;
			#else
			float scale = 1.0;
			#endif
			float4 o = pos;
			o.y = pos.w * 0.5f;
			o.y = ( pos.y - o.y ) * _ProjectionParams.x * scale + o.y;
			return o;
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float2 appendResult6_g46 = (float2(_VTOTex_Uspeed , _VTOTex_Vspeed));
			float4 break18_g44 = _VTOTex_ST;
			float2 appendResult1_g44 = (float2(break18_g44.x , break18_g44.y));
			float2 appendResult3_g44 = (float2(break18_g44.z , break18_g44.w));
			float2 appendResult866 = (float2(_CenterU , _CenterV));
			float2 centeruv867 = appendResult866;
			float2 CenteredUV15_g45 = ( v.texcoord.xy - centeruv867 );
			float2 break17_g45 = CenteredUV15_g45;
			float2 appendResult23_g45 = (float2(( length( CenteredUV15_g45 ) * break18_g44.x * 2.0 ) , ( atan2( break17_g45.x , break17_g45.y ) * ( 1.0 / 6.28318548202515 ) * break18_g44.y )));
			float3 ase_vertex3Pos = v.vertex.xyz;
			float4 break537 = ( _TexCenter + float4( ase_vertex3Pos , 0.0 ) );
			float2 appendResult554 = (float2((0.0 + (atan( ( break537.x / break537.z ) ) - ( -0.5 * UNITY_PI )) * (1.0 - 0.0) / (( 0.5 * UNITY_PI ) - ( -0.5 * UNITY_PI ))) , break537.y));
			float2 appendResult553 = (float2((0.0 + (atan( ( break537.y / break537.z ) ) - ( -0.5 * UNITY_PI )) * (1.0 - 0.0) / (( 0.5 * UNITY_PI ) - ( -0.5 * UNITY_PI ))) , break537.x));
			float2 appendResult555 = (float2((0.0 + (atan( ( break537.x / break537.y ) ) - ( -0.5 * UNITY_PI )) * (1.0 - 0.0) / (( 0.5 * UNITY_PI ) - ( -0.5 * UNITY_PI ))) , break537.z));
			#if defined(_FACE_X)
				float2 staticSwitch556 = appendResult553;
			#elif defined(_FACE_Y)
				float2 staticSwitch556 = appendResult554;
			#elif defined(_FACE_Z)
				float2 staticSwitch556 = appendResult555;
			#else
				float2 staticSwitch556 = appendResult554;
			#endif
			float2 maintongUV557 = staticSwitch556;
			#if defined(_MAINTEXUVS_NORMAL)
				float2 staticSwitch841 = ( ( v.texcoord.xy * appendResult1_g44 ) + appendResult3_g44 );
			#elif defined(_MAINTEXUVS_POLAR)
				float2 staticSwitch841 = ( appendResult23_g45 + appendResult3_g44 );
			#elif defined(_MAINTEXUVS_CYLINDER)
				float2 staticSwitch841 = ( ( maintongUV557 * appendResult1_g44 ) + appendResult3_g44 );
			#else
				float2 staticSwitch841 = ( ( v.texcoord.xy * appendResult1_g44 ) + appendResult3_g44 );
			#endif
			float2 panner7_g46 = ( 1.0 * _Time.y * appendResult6_g46 + staticSwitch841);
			float cos9_g46 = cos( ( ( ( _VTOR / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float sin9_g46 = sin( ( ( ( _VTOR / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float2 rotator9_g46 = mul( panner7_g46 - float2( 0.5,0.5 ) , float2x2( cos9_g46 , -sin9_g46 , sin9_g46 , cos9_g46 )) + float2( 0.5,0.5 );
			float2 break13_g46 = rotator9_g46;
			float2 break10_g46 = rotator9_g46;
			float clampResult11_g46 = clamp( break10_g46.x , 0.0 , 1.0 );
			float clampResult12_g46 = clamp( break10_g46.y , 0.0 , 1.0 );
			float2 appendResult370 = (float2((( _VTOC )?( clampResult11_g46 ):( break13_g46.x )) , (( _VTOCV )?( clampResult12_g46 ):( break13_g46.y ))));
			float4 tex2DNode72 = tex2Dlod( _VTOTex, float4( appendResult370, 0, 0.0) );
			float3 ase_vertexNormal = v.normal.xyz;
			float4 break18_g47 = _VTOMaskTex_ST;
			float2 appendResult1_g47 = (float2(break18_g47.x , break18_g47.y));
			float2 appendResult3_g47 = (float2(break18_g47.z , break18_g47.w));
			float2 CenteredUV15_g48 = ( v.texcoord.xy - centeruv867 );
			float2 break17_g48 = CenteredUV15_g48;
			float2 appendResult23_g48 = (float2(( length( CenteredUV15_g48 ) * break18_g47.x * 2.0 ) , ( atan2( break17_g48.x , break17_g48.y ) * ( 1.0 / 6.28318548202515 ) * break18_g47.y )));
			#if defined(_MAINTEXUVS_NORMAL)
				float2 staticSwitch853 = ( ( v.texcoord.xy * appendResult1_g47 ) + appendResult3_g47 );
			#elif defined(_MAINTEXUVS_POLAR)
				float2 staticSwitch853 = ( appendResult23_g48 + appendResult3_g47 );
			#elif defined(_MAINTEXUVS_CYLINDER)
				float2 staticSwitch853 = ( ( maintongUV557 * appendResult1_g47 ) + appendResult3_g47 );
			#else
				float2 staticSwitch853 = ( ( v.texcoord.xy * appendResult1_g47 ) + appendResult3_g47 );
			#endif
			float cos263 = cos( ( ( ( _VTOMaskR / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float sin263 = sin( ( ( ( _VTOMaskR / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float2 rotator263 = mul( staticSwitch853 - float2( 0.5,0.5 ) , float2x2( cos263 , -sin263 , sin263 , cos263 )) + float2( 0.5,0.5 );
			float2 break372 = rotator263;
			float2 break371 = rotator263;
			float clampResult257 = clamp( break371.x , 0.0 , 1.0 );
			float clampResult373 = clamp( break371.y , 0.0 , 1.0 );
			float2 appendResult375 = (float2((( _VTOMaskC )?( clampResult257 ):( break372.x )) , (( _VTOMaskCV )?( clampResult373 ):( break372.y ))));
			float4 tex2DNode81 = tex2Dlod( _VTOMaskTex, float4( appendResult375, 0, 0.0) );
			float3 VTO82 = ( (( _VTOAR )?( tex2DNode72.r ):( tex2DNode72.a )) * ase_vertexNormal * (( _ToggleSwitch0 )?( v.texcoord1.w ):( _VTOFactor )) * (( _VTOMaskAR )?( tex2DNode81.r ):( tex2DNode81.a )) );
			float3 temp_cast_1 = (0.0).xxx;
			v.vertex.xyz += (( _screenVTOon )?( temp_cast_1 ):( VTO82 ));
			v.vertex.w = 1;
			float3 vertexPos88 = ase_vertex3Pos;
			float4 ase_screenPos88 = ComputeScreenPos( UnityObjectToClipPos( vertexPos88 ) );
			o.screenPosition88 = ase_screenPos88;
		}

		inline half4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return half4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			float2 appendResult6_g54 = (float2(_Mask_Uspeed , _Mask_Vspeed));
			float4 break18_g52 = _MaskTex_ST;
			float2 appendResult1_g52 = (float2(break18_g52.x , break18_g52.y));
			float2 appendResult3_g52 = (float2(break18_g52.z , break18_g52.w));
			float2 appendResult866 = (float2(_CenterU , _CenterV));
			float2 centeruv867 = appendResult866;
			float2 CenteredUV15_g53 = ( i.uv_texcoord - centeruv867 );
			float2 break17_g53 = CenteredUV15_g53;
			float2 appendResult23_g53 = (float2(( length( CenteredUV15_g53 ) * break18_g52.x * 2.0 ) , ( atan2( break17_g53.x , break17_g53.y ) * ( 1.0 / 6.28318548202515 ) * break18_g52.y )));
			float3 ase_vertex3Pos = mul( unity_WorldToObject, float4( i.worldPos , 1 ) );
			float4 break537 = ( _TexCenter + float4( ase_vertex3Pos , 0.0 ) );
			float2 appendResult554 = (float2((0.0 + (atan( ( break537.x / break537.z ) ) - ( -0.5 * UNITY_PI )) * (1.0 - 0.0) / (( 0.5 * UNITY_PI ) - ( -0.5 * UNITY_PI ))) , break537.y));
			float2 appendResult553 = (float2((0.0 + (atan( ( break537.y / break537.z ) ) - ( -0.5 * UNITY_PI )) * (1.0 - 0.0) / (( 0.5 * UNITY_PI ) - ( -0.5 * UNITY_PI ))) , break537.x));
			float2 appendResult555 = (float2((0.0 + (atan( ( break537.x / break537.y ) ) - ( -0.5 * UNITY_PI )) * (1.0 - 0.0) / (( 0.5 * UNITY_PI ) - ( -0.5 * UNITY_PI ))) , break537.z));
			#if defined(_FACE_X)
				float2 staticSwitch556 = appendResult553;
			#elif defined(_FACE_Y)
				float2 staticSwitch556 = appendResult554;
			#elif defined(_FACE_Z)
				float2 staticSwitch556 = appendResult555;
			#else
				float2 staticSwitch556 = appendResult554;
			#endif
			float2 maintongUV557 = staticSwitch556;
			#if defined(_MASKTEXUVS_NORMAL)
				float2 staticSwitch781 = ( ( i.uv_texcoord * appendResult1_g52 ) + appendResult3_g52 );
			#elif defined(_MASKTEXUVS_POLAR)
				float2 staticSwitch781 = ( appendResult23_g53 + appendResult3_g52 );
			#elif defined(_MASKTEXUVS_CYLINDER)
				float2 staticSwitch781 = ( ( maintongUV557 * appendResult1_g52 ) + appendResult3_g52 );
			#else
				float2 staticSwitch781 = ( ( i.uv_texcoord * appendResult1_g52 ) + appendResult3_g52 );
			#endif
			float2 appendResult58 = (float2(_DistortTex_Uspeed , _DistortTex_Vspeed));
			float4 break18_g42 = _DistortTex_ST;
			float2 appendResult1_g42 = (float2(break18_g42.x , break18_g42.y));
			float2 appendResult3_g42 = (float2(break18_g42.z , break18_g42.w));
			float2 CenteredUV15_g43 = ( i.uv_texcoord - centeruv867 );
			float2 break17_g43 = CenteredUV15_g43;
			float2 appendResult23_g43 = (float2(( length( CenteredUV15_g43 ) * break18_g42.x * 2.0 ) , ( atan2( break17_g43.x , break17_g43.y ) * ( 1.0 / 6.28318548202515 ) * break18_g42.y )));
			#if defined(_MAINTEXUVS_NORMAL)
				float2 staticSwitch829 = ( ( i.uv_texcoord * appendResult1_g42 ) + appendResult3_g42 );
			#elif defined(_MAINTEXUVS_POLAR)
				float2 staticSwitch829 = ( appendResult23_g43 + appendResult3_g42 );
			#elif defined(_MAINTEXUVS_CYLINDER)
				float2 staticSwitch829 = ( ( maintongUV557 * appendResult1_g42 ) + appendResult3_g42 );
			#else
				float2 staticSwitch829 = ( ( i.uv_texcoord * appendResult1_g42 ) + appendResult3_g42 );
			#endif
			float2 panner59 = ( 1.0 * _Time.y * appendResult58 + staticSwitch829);
			float4 tex2DNode54 = tex2D( _DistortTex, panner59 );
			float2 appendResult61 = (float2(tex2DNode54.r , tex2DNode54.g));
			float2 DistortUV60 = appendResult61;
			float lerpResult450 = lerp( _DistortFactor , i.uv3_tex4coord3.w , _CustomDistort);
			float normalscale891 = lerpResult450;
			float lerpResult910 = lerp( 0.0 , normalscale891 , _DistortMask);
			float2 lerpResult905 = lerp( staticSwitch781 , DistortUV60 , lerpResult910);
			float2 temp_cast_1 = (0.0).xx;
			float2 panner7_g54 = ( 1.0 * _Time.y * appendResult6_g54 + ( lerpResult905 + (( _CustomdataMaskUV )?( i.uv3_texcoord3 ):( temp_cast_1 )) ));
			float cos9_g54 = cos( ( ( ( _Mask_rotat / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float sin9_g54 = sin( ( ( ( _Mask_rotat / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float2 rotator9_g54 = mul( panner7_g54 - float2( 0.5,0.5 ) , float2x2( cos9_g54 , -sin9_g54 , sin9_g54 , cos9_g54 )) + float2( 0.5,0.5 );
			float2 break13_g54 = rotator9_g54;
			float2 break10_g54 = rotator9_g54;
			float clampResult11_g54 = clamp( break10_g54.x , 0.0 , 1.0 );
			float clampResult12_g54 = clamp( break10_g54.y , 0.0 , 1.0 );
			float2 appendResult365 = (float2((( _MaskC )?( clampResult11_g54 ):( break13_g54.x )) , (( _MaskCV )?( clampResult12_g54 ):( break13_g54.y ))));
			float4 tex2DNode52 = tex2D( _MaskTex, appendResult365 );
			float MaskAlpha136 = ( _Mask_scale * (( _MaskAlphaRA )?( tex2DNode52.r ):( tex2DNode52.a )) );
			float lerpResult746 = lerp( i.vertexColor.a , 1.0 , _CustomdataDisT);
			float2 appendResult6_g36 = (float2(_MainTex_Uspeed , _MainTex_Vspeed));
			float2 temp_cast_2 = (0.0).xx;
			float4 break18_g32 = _MainTex_ST;
			float2 appendResult1_g32 = (float2(break18_g32.x , break18_g32.y));
			float2 appendResult3_g32 = (float2(break18_g32.z , break18_g32.w));
			float2 CenteredUV15_g33 = ( i.uv_texcoord - centeruv867 );
			float2 break17_g33 = CenteredUV15_g33;
			float2 appendResult23_g33 = (float2(( length( CenteredUV15_g33 ) * break18_g32.x * 2.0 ) , ( atan2( break17_g33.x , break17_g33.y ) * ( 1.0 / 6.28318548202515 ) * break18_g32.y )));
			#if defined(_MAINTEXUVS_NORMAL)
				float2 staticSwitch607 = ( ( i.uv_texcoord * appendResult1_g32 ) + appendResult3_g32 );
			#elif defined(_MAINTEXUVS_POLAR)
				float2 staticSwitch607 = ( appendResult23_g33 + appendResult3_g32 );
			#elif defined(_MAINTEXUVS_CYLINDER)
				float2 staticSwitch607 = ( ( maintongUV557 * appendResult1_g32 ) + appendResult3_g32 );
			#else
				float2 staticSwitch607 = ( ( i.uv_texcoord * appendResult1_g32 ) + appendResult3_g32 );
			#endif
			float lerpResult118 = lerp( 0.0 , normalscale891 , _DistortMainTex);
			float2 lerpResult890 = lerp( staticSwitch607 , DistortUV60 , lerpResult118);
			float2 panner7_g36 = ( 1.0 * _Time.y * appendResult6_g36 + ( (( _CustomdataMainTexUV )?( i.uv2_texcoord2 ):( temp_cast_2 )) + lerpResult890 ));
			float cos9_g36 = cos( ( ( ( _MainTex_rotat / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float sin9_g36 = sin( ( ( ( _MainTex_rotat / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float2 rotator9_g36 = mul( panner7_g36 - float2( 0.5,0.5 ) , float2x2( cos9_g36 , -sin9_g36 , sin9_g36 , cos9_g36 )) + float2( 0.5,0.5 );
			float2 break13_g36 = rotator9_g36;
			float2 break10_g36 = rotator9_g36;
			float clampResult11_g36 = clamp( break10_g36.x , 0.0 , 1.0 );
			float clampResult12_g36 = clamp( break10_g36.y , 0.0 , 1.0 );
			float2 appendResult355 = (float2((( _MaintexC )?( clampResult11_g36 ):( break13_g36.x )) , (( _MaintexCV )?( clampResult12_g36 ):( break13_g36.y ))));
			float4 tex2DNode1 = tex2D( _MainTex, appendResult355 );
			float4 ase_screenPos = float4( i.screenPos.xyz , i.screenPos.w + 0.00000000001 );
			float4 ase_grabScreenPos = ASE_ComputeGrabScreenPos( ase_screenPos );
			float4 ase_grabScreenPosNorm = ase_grabScreenPos / ase_grabScreenPos.w;
			float4 lerpResult923 = lerp( ase_grabScreenPosNorm , float4( DistortUV60, 0.0 , 0.0 ) , lerpResult118);
			float4 screenColor917 = UNITY_SAMPLE_SCREENSPACE_TEXTURE(_GrabTexture,lerpResult923.xy);
			float lerpResult921 = lerp( (( _MainTex_ar )?( tex2DNode1.r ):( tex2DNode1.a )) , screenColor917.a , _ScreenAsMain);
			float MainTexAlpha37 = ( lerpResult746 * lerpResult921 * _MainColor.a * _MainAlpha );
			float lerpResult743 = lerp( i.uv2_tex4coord2.z , (1.0 + (i.vertexColor.a - 0.0) * (0.0 - 1.0) / (1.0 - 0.0)) , _CustomdataDisT);
			float temp_output_882_0 = ( ( _DIssloveSoft + 1.0 ) * (( _CustomdataDis )?( lerpResult743 ):( ( _DIssloveFactor + 0.001 ) )) );
			float2 appendResult6_g39 = (float2(_DisTex_Uspeed , _DisTex_Vspeed));
			float4 break18_g37 = _DissloveTex_ST;
			float2 appendResult1_g37 = (float2(break18_g37.x , break18_g37.y));
			float2 appendResult3_g37 = (float2(break18_g37.z , break18_g37.w));
			float2 CenteredUV15_g38 = ( i.uv_texcoord - centeruv867 );
			float2 break17_g38 = CenteredUV15_g38;
			float2 appendResult23_g38 = (float2(( length( CenteredUV15_g38 ) * break18_g37.x * 2.0 ) , ( atan2( break17_g38.x , break17_g38.y ) * ( 1.0 / 6.28318548202515 ) * break18_g37.y )));
			#if defined(_DISSOLVETEXUVS_NORMAL)
				float2 staticSwitch805 = ( ( i.uv_texcoord * appendResult1_g37 ) + appendResult3_g37 );
			#elif defined(_DISSOLVETEXUVS_POLAR)
				float2 staticSwitch805 = ( appendResult23_g38 + appendResult3_g37 );
			#elif defined(_DISSOLVETEXUVS_CYLINDER)
				float2 staticSwitch805 = ( ( maintongUV557 * appendResult1_g37 ) + appendResult3_g37 );
			#else
				float2 staticSwitch805 = ( ( i.uv_texcoord * appendResult1_g37 ) + appendResult3_g37 );
			#endif
			float lerpResult904 = lerp( 0.0 , normalscale891 , _DistortDisTex);
			float2 lerpResult899 = lerp( staticSwitch805 , DistortUV60 , lerpResult904);
			float2 panner7_g39 = ( 1.0 * _Time.y * appendResult6_g39 + lerpResult899);
			float cos9_g39 = cos( ( ( ( _DIssolve_rotat / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float sin9_g39 = sin( ( ( ( _DIssolve_rotat / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float2 rotator9_g39 = mul( panner7_g39 - float2( 0.5,0.5 ) , float2x2( cos9_g39 , -sin9_g39 , sin9_g39 , cos9_g39 )) + float2( 0.5,0.5 );
			float2 break13_g39 = rotator9_g39;
			float2 break10_g39 = rotator9_g39;
			float clampResult11_g39 = clamp( break10_g39.x , 0.0 , 1.0 );
			float clampResult12_g39 = clamp( break10_g39.y , 0.0 , 1.0 );
			float2 appendResult360 = (float2((( _DissolveC )?( clampResult11_g39 ):( break13_g39.x )) , (( _DissolveCV )?( clampResult12_g39 ):( break13_g39.y ))));
			float4 tex2DNode25 = tex2D( _DissloveTex, appendResult360 );
			float4 break18_g40 = _DissloveTexPlus_ST;
			float2 appendResult1_g40 = (float2(break18_g40.x , break18_g40.y));
			float2 appendResult3_g40 = (float2(break18_g40.z , break18_g40.w));
			float2 CenteredUV15_g41 = ( i.uv_texcoord - centeruv867 );
			float2 break17_g41 = CenteredUV15_g41;
			float2 appendResult23_g41 = (float2(( length( CenteredUV15_g41 ) * break18_g40.x * 2.0 ) , ( atan2( break17_g41.x , break17_g41.y ) * ( 1.0 / 6.28318548202515 ) * break18_g40.y )));
			#if defined(_DISSOLVETEXUVS_NORMAL)
				float2 staticSwitch817 = ( ( i.uv_texcoord * appendResult1_g40 ) + appendResult3_g40 );
			#elif defined(_DISSOLVETEXUVS_POLAR)
				float2 staticSwitch817 = ( appendResult23_g41 + appendResult3_g40 );
			#elif defined(_DISSOLVETEXUVS_CYLINDER)
				float2 staticSwitch817 = ( ( maintongUV557 * appendResult1_g40 ) + appendResult3_g40 );
			#else
				float2 staticSwitch817 = ( ( i.uv_texcoord * appendResult1_g40 ) + appendResult3_g40 );
			#endif
			float cos529 = cos( ( ( ( _DissolvePlusR / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float sin529 = sin( ( ( ( _DissolvePlusR / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float2 rotator529 = mul( staticSwitch817 - float2( 0.5,0.5 ) , float2x2( cos529 , -sin529 , sin529 , cos529 )) + float2( 0.5,0.5 );
			float2 break512 = rotator529;
			float2 break510 = rotator529;
			float clampResult513 = clamp( break510.x , 0.0 , 1.0 );
			float clampResult511 = clamp( break510.y , 0.0 , 1.0 );
			float2 appendResult516 = (float2((( _DissolvePlusC )?( clampResult513 ):( break512.x )) , (( _DissolvePlusCV )?( clampResult511 ):( break512.y ))));
			float4 tex2DNode506 = tex2D( _DissloveTexPlus, appendResult516 );
			float temp_output_518_0 = saturate( ( ( ( (( _DissolveAR )?( tex2DNode25.r ):( tex2DNode25.a )) / _DissolveTexDivide ) + (( _IfDissolvePlus )?( (( _DissolvePlusAR )?( tex2DNode506.r ):( tex2DNode506.a )) ):( (( _DissolveAR )?( tex2DNode25.r ):( tex2DNode25.a )) )) ) / 2.0 ) );
			float smoothstepResult27 = smoothstep( ( temp_output_882_0 - _DIssloveSoft ) , temp_output_882_0 , temp_output_518_0);
			float temp_output_885_0 = ( (( _CustomdataDis )?( lerpResult743 ):( ( _DIssloveFactor + 0.001 ) )) * ( 1.0 + _DIssloveWide ) );
			float temp_output_233_0 = step( ( temp_output_885_0 - _DIssloveWide ) , temp_output_518_0 );
			float DisAplha42 = (( _sot_sting_A )?( temp_output_233_0 ):( smoothstepResult27 ));
			float3 ase_worldNormal = i.worldNormal;
			float dotResult106 = dot( i.viewDir , ase_worldNormal );
			float softedge111 = pow( saturate( abs( dotResult106 ) ) , _softFacotr );
			float4 ase_screenPos88 = i.screenPosition88;
			float4 ase_screenPosNorm88 = ase_screenPos88 / ase_screenPos88.w;
			ase_screenPosNorm88.z = ( UNITY_NEAR_CLIP_VALUE >= 0 ) ? ase_screenPosNorm88.z : ase_screenPosNorm88.z * 0.5 + 0.5;
			float screenDepth88 = LinearEyeDepth(SAMPLE_DEPTH_TEXTURE( _CameraDepthTexture, ase_screenPosNorm88.xy ));
			float distanceDepth88 = saturate( ( screenDepth88 - LinearEyeDepth( ase_screenPosNorm88.z ) ) / ( _DepthfadeFactor ) );
			float lerpResult413 = lerp( distanceDepth88 , 1.0 , _DepthF);
			float temp_output_409_0 = ( 1.0 - saturate( distanceDepth88 ) );
			float lerpResult416 = lerp( 0.0 , temp_output_409_0 , _DepthF);
			float MainAlpha142 = saturate( ( ( MaskAlpha136 * MainTexAlpha37 * DisAplha42 * (( _FNLfanxiangkaiguan )?( softedge111 ):( 1.0 )) * (( _Depthfadeon )?( lerpResult413 ):( 1.0 )) ) + lerpResult416 ) );
			float4 DepthColor412 = ( temp_output_409_0 * _DepthColor );
			float4 lerpResult422 = lerp( float4( 0,0,0,0 ) , DepthColor412 , _DepthF);
			float3 normalizeResult407 = normalize( ( i.viewDir + _Dir ) );
			float fresnelNdotV91 = dot( ase_worldNormal, normalizeResult407 );
			float fresnelNode91 = ( 0.0 + _fnl_sacle * pow( 1.0 - fresnelNdotV91, _fnl_power ) );
			float switchResult438 = (((i.ASEVFace>0)?(saturate( fresnelNode91 )):(0.0)));
			float4 fnlColor97 = ( switchResult438 * _fnl_color * i.vertexColor );
			float4 lerpResult920 = lerp( tex2DNode1 , screenColor917 , _ScreenAsMain);
			float4 temp_cast_5 = (1.0).xxxx;
			float4 MaskColor439 = tex2DNode52;
			float4 temp_output_223_0 = ( _MainColor * lerpResult920 * (( _IfMaskColor )?( MaskColor439 ):( temp_cast_5 )) );
			float4 temp_cast_6 = (1.0).xxxx;
			float2 appendResult6_g51 = (float2(_AddTexUspeed , _AddTexVspeed));
			float4 break18_g49 = _AddTex_ST;
			float2 appendResult1_g49 = (float2(break18_g49.x , break18_g49.y));
			float2 appendResult3_g49 = (float2(break18_g49.z , break18_g49.w));
			float2 CenteredUV15_g50 = ( i.uv_texcoord - centeruv867 );
			float2 break17_g50 = CenteredUV15_g50;
			float2 appendResult23_g50 = (float2(( length( CenteredUV15_g50 ) * break18_g49.x * 2.0 ) , ( atan2( break17_g50.x , break17_g50.y ) * ( 1.0 / 6.28318548202515 ) * break18_g49.y )));
			#if defined(_MAINTEXUVS_NORMAL)
				float2 staticSwitch793 = ( ( i.uv_texcoord * appendResult1_g49 ) + appendResult3_g49 );
			#elif defined(_MAINTEXUVS_POLAR)
				float2 staticSwitch793 = ( appendResult23_g50 + appendResult3_g49 );
			#elif defined(_MAINTEXUVS_CYLINDER)
				float2 staticSwitch793 = ( ( maintongUV557 * appendResult1_g49 ) + appendResult3_g49 );
			#else
				float2 staticSwitch793 = ( ( i.uv_texcoord * appendResult1_g49 ) + appendResult3_g49 );
			#endif
			float lerpResult896 = lerp( 0.0 , normalscale891 , _DistortAddTex);
			float2 lerpResult897 = lerp( staticSwitch793 , DistortUV60 , lerpResult896);
			float2 panner7_g51 = ( 1.0 * _Time.y * appendResult6_g51 + lerpResult897);
			float cos9_g51 = cos( ( ( ( _AddTexRo / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float sin9_g51 = sin( ( ( ( _AddTexRo / 360.0 ) * UNITY_PI ) * 2.0 ) );
			float2 rotator9_g51 = mul( panner7_g51 - float2( 0.5,0.5 ) , float2x2( cos9_g51 , -sin9_g51 , sin9_g51 , cos9_g51 )) + float2( 0.5,0.5 );
			float2 break13_g51 = rotator9_g51;
			float2 break10_g51 = rotator9_g51;
			float clampResult11_g51 = clamp( break10_g51.x , 0.0 , 1.0 );
			float clampResult12_g51 = clamp( break10_g51.y , 0.0 , 1.0 );
			float2 appendResult477 = (float2((( _AddTexC )?( clampResult11_g51 ):( break13_g51.x )) , (( _AddTexCV )?( clampResult12_g51 ):( break13_g51.y ))));
			float4 tex2DNode428 = tex2D( _AddTex, appendResult477 );
			float4 AddTexColors479 = (( _AddTexChanel )?( ( _AddTexColor * tex2DNode428.r ) ):( ( _AddTexColor * tex2DNode428 ) ));
			float4 lerpResult488 = lerp( temp_output_223_0 , AddTexColors479 , _AddTexBlend);
			float4 temp_cast_7 = (1.0).xxxx;
			#if defined(_ADDTEXBLENDMODE_LERP)
				float4 staticSwitch501 = lerpResult488;
			#elif defined(_ADDTEXBLENDMODE_ADD)
				float4 staticSwitch501 = ( AddTexColors479 + temp_output_223_0 );
			#else
				float4 staticSwitch501 = lerpResult488;
			#endif
			float4 MainColornoparticle224 = (( _IfAddTex )?( staticSwitch501 ):( temp_output_223_0 ));
			float4 lerpResult230 = lerp( MainColornoparticle224 , _DIssloveColor , _DIssloveColor.a);
			float4 lerpResult33 = lerp( lerpResult230 , MainColornoparticle224 , smoothstepResult27);
			float temp_output_234_0 = ( temp_output_233_0 - step( temp_output_885_0 , temp_output_518_0 ) );
			float4 lerpResult244 = lerp( MainColornoparticle224 , ( lerpResult230 * temp_output_234_0 ) , temp_output_234_0);
			float4 DisColor40 = ( i.vertexColor * (( _soft_sting )?( lerpResult244 ):( lerpResult33 )) );
			float4 temp_output_145_0 = ( (( _AlphaAdd )?( MainAlpha142 ):( 1.0 )) * ( lerpResult422 + ( fnlColor97 + DisColor40 ) ) );
			float4 switchResult433 = (((i.ASEVFace>0)?(temp_output_145_0):(( temp_output_145_0 * _BackFaceColor ))));
			float3 desaturateInitialColor299 = switchResult433.rgb;
			float desaturateDot299 = dot( desaturateInitialColor299, float3( 0.299, 0.587, 0.114 ));
			float3 desaturateVar299 = lerp( desaturateInitialColor299, desaturateDot299.xxx, _qubaohedu );
			o.Emission = desaturateVar299;
			o.Alpha = MainAlpha142;
		}

		ENDCG
	}
	CustomEditor "CommonGUI4"
}
