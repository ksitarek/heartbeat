SELECT a."id" AS "Id",
       a."label" AS "Label",

       COALESCE(lv."was_verification_successful", false) AS "LastVerificationStatus",
       lv."created_at" AS "LastVerificationDateTime",

       vc."id" AS "VerificationConfigurationId",
       vc."verification_strategy" AS "VerificationStrategy",
       vc."verification_token" AS "VerificationToken"
FROM "app" a

LEFT JOIN "verification_configuration" vc ON vc."app_id" = a."id"

LEFT JOIN LATERAL (
    SELECT vs."was_verification_successful",
           vs."created_at"
    FROM "verification_status" vs
             INNER JOIN "verification_configuration" vc ON vc."id" = vs."verification_configuration_id"
) lv ON TRUE

WHERE a."id" = @id;