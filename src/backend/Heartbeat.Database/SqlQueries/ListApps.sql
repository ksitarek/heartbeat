SELECT a."id"                           AS AppId,
       a."label"                        AS AppLabel,

       lv."was_verification_successful" AS LastVerificationStatus,
       lv."created_at"                  AS LastVerificationDateTime

FROM "app" a
         LEFT JOIN LATERAL (
    SELECT vs."was_verification_successful",
           vs."created_at"
    FROM "verification_status" vs
             INNER JOIN "verification_configuration" vc ON vc."id" = vs."verification_configuration_id"
    WHERE vc."app_id" = a."id"
    ORDER BY vs."created_at" DESC
    LIMIT 1
    ) lv ON TRUE

WHERE (@Search IS NULL OR (
    LOWER(a.label) LIKE LOWER(@Search) || '%'
    ))

LIMIT @Limit OFFSET @Offset