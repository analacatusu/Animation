Shader "Custom/MysteryShader4_Reversed" {
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Radius("Radius", Range(0.0, 5)) = 0.2
        _Hardness("Hardness", Range(0.01, 0.99999)) = 1.0
        _CenterPoint("Center", Vector) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alpha:fade

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        float3 _CenterPoint;
        float _Radius;
        float _Hardness;

        struct Input
        {
            float2 uv_MainTex;
            float3 viewDir;
            float3 worldNormal;
            float3 worldPos;
        };

        fixed4 _Color;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = _Color.rgb;
            o.Alpha = 1.0 - saturate((length(_CenterPoint - IN.worldPos) - _Radius) / (1.0 - _Hardness));
        }
        ENDCG
    }
    FallBack "Diffuse"
}