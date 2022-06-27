// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Walrus"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_WetColor("WetColor", Color) = (1,1,1,1)
		[Normal]_Normal("Normal", 2D) = "bump" {}
		[Normal]_WrinkleNormal("WrinkleNormal", 2D) = "bump" {}
		_Smoothness("Smoothness", Float) = 0
		_NormalSkinScale("NormalSkinScale", Float) = 0
		_NormalWrinkleScale("NormalWrinkleScale", Float) = 0
		_WaterLevel("WaterLevel", Float) = 0
		_WetSmoothness("WetSmoothness", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" }
		Cull Back
		CGPROGRAM
		#include "UnityStandardUtils.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
			float4 vertexColor : COLOR;
			float3 worldPos;
		};

		uniform sampler2D _Normal;
		uniform float4 _Normal_ST;
		uniform float _NormalSkinScale;
		uniform sampler2D _WrinkleNormal;
		uniform float4 _WrinkleNormal_ST;
		uniform float _NormalWrinkleScale;
		uniform float4 _WetColor;
		uniform float4 _Color;
		uniform float _WaterLevel;
		uniform float _WetSmoothness;
		uniform float _Smoothness;


		float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }

		float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }

		float snoise( float2 v )
		{
			const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
			float2 i = floor( v + dot( v, C.yy ) );
			float2 x0 = v - i + dot( i, C.xx );
			float2 i1;
			i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
			float4 x12 = x0.xyxy + C.xxzz;
			x12.xy -= i1;
			i = mod2D289( i );
			float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
			float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
			m = m * m;
			m = m * m;
			float3 x = 2.0 * frac( p * C.www ) - 1.0;
			float3 h = abs( x ) - 0.5;
			float3 ox = floor( x + 0.5 );
			float3 a0 = x - ox;
			m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
			float3 g;
			g.x = a0.x * x0.x + h.x * x0.y;
			g.yz = a0.yz * x12.xz + h.yz * x12.yw;
			return 130.0 * dot( m, g );
		}


		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Normal = i.uv_texcoord * _Normal_ST.xy + _Normal_ST.zw;
			float2 uv_WrinkleNormal = i.uv_texcoord * _WrinkleNormal_ST.xy + _WrinkleNormal_ST.zw;
			float3 temp_output_6_0 = BlendNormals( UnpackScaleNormal( tex2D( _Normal, uv_Normal ), ( _NormalSkinScale * i.vertexColor.b ) ) , UnpackScaleNormal( tex2D( _WrinkleNormal, uv_WrinkleNormal ), _NormalWrinkleScale ) );
			o.Normal = temp_output_6_0;
			float3 objToWorld29 = mul( unity_ObjectToWorld, float4( float3( 0,0,0 ), 1 ) ).xyz;
			float3 ase_worldPos = i.worldPos;
			float temp_output_36_0 = ( objToWorld29.y - ase_worldPos.y );
			float simplePerlin2D41 = snoise( ase_worldPos.xy );
			simplePerlin2D41 = simplePerlin2D41*0.5 + 0.5;
			float smoothstepResult44 = smoothstep( temp_output_36_0 , ( 0.1 + temp_output_36_0 ) , ( _WaterLevel + ( simplePerlin2D41 * 0.5 ) ));
			float Wet27 = smoothstepResult44;
			float4 lerpResult38 = lerp( _WetColor , _Color , Wet27);
			o.Albedo = lerpResult38.rgb;
			float lerpResult31 = lerp( _WetSmoothness , _Smoothness , Wet27);
			o.Smoothness = lerpResult31;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=18935
7;444;1896;567;1137.134;103.5409;1.6;True;False
Node;AmplifyShaderEditor.WorldPosInputsNode;34;-2091.069,-438.1641;Inherit;False;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.NoiseGeneratorNode;41;-1852.952,-260.5498;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.TransformPositionNode;29;-2097.309,-597.0173;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleSubtractOpNode;36;-1846.069,-589.1641;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;30;-1817.997,-429.5823;Inherit;False;Property;_WaterLevel;WaterLevel;10;0;Create;True;0;0;0;False;0;False;0;-0.95;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;43;-1613.369,-211.2902;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;42;-1616.071,-382.8868;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;45;-1709.094,-685.6398;Inherit;False;2;2;0;FLOAT;0.1;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;20;-2251.269,30.91492;Inherit;False;Property;_NormalSkinScale;NormalSkinScale;6;0;Create;True;0;0;0;False;0;False;0;0.52;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SmoothstepOpNode;44;-1482.445,-671.1821;Inherit;True;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.VertexColorNode;26;-2165.607,190.8285;Inherit;False;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RegisterLocalVarNode;27;-1219.834,-525.1088;Inherit;False;Wet;-1;True;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;21;-1791.905,282.0576;Inherit;False;Property;_NormalWrinkleScale;NormalWrinkleScale;7;0;Create;True;0;0;0;False;0;False;0;0.31;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;25;-1980.607,115.8285;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;39;-1007.803,-457.5647;Inherit;False;Property;_WetColor;WetColor;1;0;Create;True;0;0;0;False;0;False;1,1,1,1;0.3396226,0.1941082,0.1650053,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;32;-422.6934,183.1031;Inherit;False;Property;_WetSmoothness;WetSmoothness;11;0;Create;True;0;0;0;False;0;False;0;0.78;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.GetLocalVarNode;40;-909.6006,-69.06992;Inherit;False;27;Wet;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;2;-1036.946,-283.2098;Inherit;False;Property;_Color;Color;0;0;Create;True;0;0;0;False;0;False;1,1,1,1;0.3867925,0.1931297,0.129539,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.GetLocalVarNode;33;-363.8931,382.0675;Inherit;False;27;Wet;1;0;OBJECT;;False;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-418.8794,276.6146;Inherit;False;Property;_Smoothness;Smoothness;4;0;Create;True;0;0;0;False;0;False;0;-0.01;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;5;-1419.564,371.1506;Inherit;True;Property;_WrinkleNormal;WrinkleNormal;3;1;[Normal];Create;True;0;0;0;False;0;False;-1;None;d0ecfe6c314cbf24d9961b67aef9d764;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;4;-1589.468,29.11971;Inherit;True;Property;_Normal;Normal;2;1;[Normal];Create;True;0;0;0;False;0;False;-1;None;f12cacfb79a6fc347989b8e2a661dc76;True;0;True;bump;Auto;True;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NegateNode;70;842.8021,545.3009;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.LerpOp;31;-163.6934,209.1031;Inherit;False;3;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;51;323.3721,677.0623;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;56;842.1505,-62.95653;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.RangedFloatNode;50;13.47236,816.2639;Inherit;False;Property;_VertexNormalStrength;Vertex Normal Strength;12;0;Create;True;0;0;0;False;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;47;-1478.996,-100.0357;Inherit;False;Constant;_Float0;Float 0;12;0;Create;True;0;0;0;False;0;False;0.5;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;24;-2310.242,-217.5089;Inherit;True;Property;_TextureSample0;Texture Sample 0;9;0;Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;bump;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;13;-347.3694,484.3861;Inherit;False;Property;_VertexAmplitude;VertexAmplitude;5;0;Create;True;0;0;0;False;0;False;0;0.61;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;57;546.3683,-112.2961;Inherit;False;Constant;_Vector1;Vector 1;13;0;Create;True;0;0;0;False;0;False;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;11;-102.063,530.3008;Inherit;False;3;3;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;2;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.WorldNormalVector;19;-854.4203,629.3846;Inherit;False;False;1;0;FLOAT3;0,0,1;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.LerpOp;38;-587.4763,-270.1021;Inherit;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;68;856.9879,246.3081;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleAddOpNode;14;-648.0043,762.7435;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT;0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SamplerNode;22;-1347.316,599.798;Inherit;True;Property;_Normal2;Normal2;8;1;[Normal];Create;True;0;0;0;False;0;False;-1;None;None;True;0;False;bump;Auto;False;Object;-1;Auto;Texture2D;8;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;6;FLOAT;0;False;7;SAMPLERSTATE;;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.NormalVertexDataNode;8;-528.2197,490.2703;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.OneMinusNode;58;518.9156,83.36345;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalVertexDataNode;49;142.3907,640.7851;Inherit;False;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BlendNormalsNode;6;-1063.598,164.1092;Inherit;True;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;72;531.8093,232.6062;Inherit;False;2;2;0;FLOAT;0;False;1;FLOAT;1.5;False;1;FLOAT;0
Node;AmplifyShaderEditor.BreakToComponentsNode;69;685.9804,436.4625;Inherit;False;FLOAT3;1;0;FLOAT3;0,0,0;False;16;FLOAT;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4;FLOAT;5;FLOAT;6;FLOAT;7;FLOAT;8;FLOAT;9;FLOAT;10;FLOAT;11;FLOAT;12;FLOAT;13;FLOAT;14;FLOAT;15
Node;AmplifyShaderEditor.SimpleSubtractOpNode;55;391.5788,180.4308;Inherit;False;2;0;FLOAT;0;False;1;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.NormalizeNode;67;301.8837,414.6965;Inherit;True;False;1;0;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.TransformPositionNode;53;150.3099,39.80737;Inherit;False;Object;World;False;Fast;True;1;0;FLOAT3;0,0,0;False;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.SimpleAddOpNode;64;1002.789,117.2537;Inherit;False;2;2;0;FLOAT3;0,0,0;False;1;FLOAT4;0,0,0,0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.SimpleTimeNode;18;-992.0043,934.7435;Inherit;False;1;0;FLOAT;1;False;1;FLOAT;0
Node;AmplifyShaderEditor.Vector3Node;54;170.7788,236.3308;Inherit;False;Constant;_Vector0;Vector 0;13;0;Create;True;0;0;0;False;0;False;0,0,1;0,0,0;0;4;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3
Node;AmplifyShaderEditor.PosVertexDataNode;66;101.7946,459.8099;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.PosVertexDataNode;52;-68.2901,26.50737;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.DynamicAppendNode;71;1035.903,449.3356;Inherit;False;FLOAT4;4;0;FLOAT;0;False;1;FLOAT;0;False;2;FLOAT;0;False;3;FLOAT;0;False;1;FLOAT4;0
Node;AmplifyShaderEditor.NoiseGeneratorNode;9;-441.8661,678.3045;Inherit;True;Simplex2D;True;False;2;0;FLOAT2;0,0;False;1;FLOAT;0.25;False;1;FLOAT;0
Node;AmplifyShaderEditor.PosVertexDataNode;10;-987.3621,782.001;Inherit;False;0;0;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.BlendNormalsNode;23;-738.902,341.548;Inherit;False;0;3;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;1;FLOAT3;0
Node;AmplifyShaderEditor.SaturateNode;61;672.7491,87.40801;Inherit;False;1;0;FLOAT;0;False;1;FLOAT;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;1208.74,-274.5468;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;Walrus;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;41;0;34;0
WireConnection;36;0;29;2
WireConnection;36;1;34;2
WireConnection;43;0;41;0
WireConnection;42;0;30;0
WireConnection;42;1;43;0
WireConnection;45;1;36;0
WireConnection;44;0;42;0
WireConnection;44;1;36;0
WireConnection;44;2;45;0
WireConnection;27;0;44;0
WireConnection;25;0;20;0
WireConnection;25;1;26;3
WireConnection;5;5;21;0
WireConnection;4;5;25;0
WireConnection;70;0;69;2
WireConnection;31;0;32;0
WireConnection;31;1;7;0
WireConnection;31;2;33;0
WireConnection;51;0;49;0
WireConnection;51;1;50;0
WireConnection;56;0;57;0
WireConnection;56;1;61;0
WireConnection;11;0;8;0
WireConnection;11;1;9;0
WireConnection;11;2;13;0
WireConnection;38;0;39;0
WireConnection;38;1;2;0
WireConnection;38;2;40;0
WireConnection;68;0;61;0
WireConnection;68;1;71;0
WireConnection;14;0;10;0
WireConnection;14;1;18;0
WireConnection;58;0;72;0
WireConnection;6;0;4;0
WireConnection;6;1;5;0
WireConnection;72;0;55;0
WireConnection;69;0;67;0
WireConnection;55;0;53;2
WireConnection;55;1;54;3
WireConnection;67;0;66;0
WireConnection;53;0;52;0
WireConnection;64;0;56;0
WireConnection;64;1;68;0
WireConnection;71;0;69;0
WireConnection;71;1;69;1
WireConnection;71;2;70;0
WireConnection;9;0;14;0
WireConnection;23;0;6;0
WireConnection;23;1;22;0
WireConnection;61;0;58;0
WireConnection;0;0;38;0
WireConnection;0;1;6;0
WireConnection;0;4;31;0
ASEEND*/
//CHKSM=9C7608C8565978607A21BD25C5AC736CE88A4CC5