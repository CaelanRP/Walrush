// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "StylizedWater/Particle/Desktop"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		[Toggle]_Unlit("Unlit", Float) = 0
		[NoScaleOffset]_MainTex("MainTex", 2D) = "white" {}
		[NoScaleOffset]_Disolve("Disolve", 2D) = "white" {}
		[HDR]_Tint("Tint", Color) = (1,1,1,1)
		[HideInInspector] _texcoord2( "", 2D ) = "white" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "TransparentCutout"  "Queue" = "AlphaTest+1" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Off
		CGPROGRAM
		#pragma target 2.0
		#pragma exclude_renderers vulkan xboxseries playstation psp2 wiiu switch nomrt 
		#pragma surface surf Lambert keepalpha addshadow fullforwardshadows nolightmap  nodirlightmap 
		struct Input
		{
			float4 vertexColor : COLOR;
			float2 uv2_texcoord2;
			float2 uv_texcoord;
		};

		uniform float4 _Tint;
		uniform half _Unlit;
		uniform sampler2D _Disolve;
		uniform sampler2D _MainTex;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutput o )
		{
			o.Albedo = ( _Tint * i.vertexColor ).rgb;
			o.Emission = (( _Unlit )?( i.vertexColor ):( float4( 0,0,0,0 ) )).rgb;
			o.Alpha = 1;
			float2 uv2_Disolve2 = i.uv2_texcoord2;
			float2 uv_MainTex8 = i.uv_texcoord;
			clip( ( step( ( 1.0 - i.vertexColor.a ) , (0.0 + (tex2D( _Disolve, uv2_Disolve2 ).r - -1.0) * (1.0 - 0.0) / (1.0 - -1.0)) ) * tex2D( _MainTex, uv_MainTex8 ).r ) - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
}
/*ASEBEGIN
Version=18935
-1867;315;1650;704;941.0067;370.6085;1.019267;True;True
Node;AmplifyShaderEditor.SamplerNode;2;-515.8998,198.6998;Inherit;True;Property;_Disolve;Disolve;3;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;c62f18931d75d8c4b8c23bac5e7731bc;c62f18931d75d8c4b8c23bac5e7731bc;True;1;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.VertexColorNode;5;-279.6001,-75.8;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;6;-26.69991,99.89997;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.TFHCRemapNode;3;-155,227;Inherit;False;5;0;FLOAT;0;False;1;FLOAT;-1;False;2;FLOAT;1;False;3;FLOAT;0;False;4;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;8;90.59988,314.8;Inherit;True;Property;_MainTex;MainTex;2;1;[NoScaleOffset];Create;True;0;0;0;False;0;False;-1;9f44b7ad0e44aef419f97ec818f3d22f;9f44b7ad0e44aef419f97ec818f3d22f;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StepOpNode;4;180.1,164;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;11;-193.8842,-242.1809;Inherit;False;Property;_Tint;Tint;4;1;[HDR];Create;True;0;0;0;False;0;False;1,1,1,1;0,0,0,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;494.9,219.6;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ToggleSwitchNode;9;414.3328,41.12207;Half;False;Property;_Unlit;Unlit;1;0;Create;True;0;0;0;False;0;False;0;True;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;104.8518,-146.0376;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;697.6998,-4.7;Float;False;True;-1;0;;0;0;Lambert;StylizedWater/Particle/Desktop;False;False;False;False;False;False;True;False;True;False;False;False;False;False;True;False;False;False;False;False;False;Off;1;False;-1;3;False;-1;False;1;False;-1;0;False;-1;False;0;Masked;0.5;True;True;1;False;TransparentCutout;;AlphaTest;All;11;d3d9;d3d11_9x;d3d11;glcore;gles;gles3;metal;xbox360;xboxone;ps4;n3ds;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;0;4;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;1;False;-1;1;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;15;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;6;0;5;4
WireConnection;3;0;2;1
WireConnection;4;0;6;0
WireConnection;4;1;3;0
WireConnection;7;0;4;0
WireConnection;7;1;8;1
WireConnection;9;1;5;0
WireConnection;10;0;11;0
WireConnection;10;1;5;0
WireConnection;0;0;10;0
WireConnection;0;2;9;0
WireConnection;0;10;7;0
ASEEND*/
//CHKSM=60781C839C99D66B9510B4827A981FA62A28A2CB