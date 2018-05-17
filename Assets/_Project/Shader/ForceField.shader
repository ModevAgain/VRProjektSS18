Shader "Unlit/ForceField"
{
	Properties
	{
		_Color("Color",Color) = (1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_NoiseTex ("Noise", 2D) = "white" {}
		_Level ("Dissolution level", Range (0.0, 1.0)) = 0.1
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent"}
		LOD 100

		Pass
		{
		Blend SrcAlpha OneMinusSrcAlpha
			Cull Off
        	Lighting Off
        	ZWrite Off
        	Fog { Mode Off }

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			sampler2D _NoiseTex;
			float _Level;
			fixed4 _Color;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				float cutout = tex2D(_NoiseTex, i.uv).r;

				if (cutout < _Level)
					discard;
				col = col * _Color;
				col.a = col.r * 0.5;


				return col;
			}
			ENDCG
		}
	}
}
