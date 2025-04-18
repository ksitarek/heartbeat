SELECT a."id"                           AS AppId,
       a."label"                        AS AppLabel,

       lc."status"                      AS LastCheckStatus,
       lc."created_at"                  AS LastCheckDateTime,

       lv."was_verification_successful" AS LastVerificationStatus,
       lv."created_at"                  AS LastVerificationDateTime

FROM "app" a

         LEFT JOIN LATERAL (
    SELECT c."label" AS check_label,
           csl."status",
           csl."created_at"
    FROM "check" c
             LEFT JOIN "check_status_log" csl ON c."id" = csl."check_id"
    WHERE c."app_id" = a."id"
    ORDER BY csl."created_at" DESC
    LIMIT 1
    ) lc ON TRUE

         LEFT JOIN LATERAL (
    SELECT "verification_strategy",
           "was_verification_successful",
           "created_at"
    FROM "verification_status"
    WHERE "app_id" = a."id"
    ORDER BY "created_at" DESC
    LIMIT 1
    ) lv ON TRUE

LIMIT @Limit OFFSET @Offset